import os
import socket
import time
import urllib.parse
import urllib.parse
from queue import Queue
from random import randint, seed
from threading import Thread
from flask import Flask, request
from flask_cors import CORS
from pygame import mixer

queue = Queue()
MUSIC_FOLDER = 'D:\Shared\_music'
ALARM_FOLDER = '_alarm'
ALARM_PLAY_TIME = 60 * 60 * 1
is_playing = False
is_alarming = False
alarm_play_count = 0
play_volume = 8
played_file = ''
REFRESH_WEB_SECS = 3

flask_app = Flask('flask_app')
flask_app.config['SECRET_KEY'] = 'secret'
flask_app.config['CORS_HEADERS'] = 'Content-type'
cors = CORS(flask_app)



def get_params(path):
    parsed = urllib.parse.urlparse(path)
    params_dict = urllib.parse.parse_qs(parsed.query)
    return params_dict



def get_path_folder(path):
    parsed = urllib.parse.urlparse(path)
    return parsed.path[1:]



def create_web():
    play_mode = 'Idle'
    if is_playing:
        play_mode = f'Playing: {played_file}'
    if is_alarming:
        play_mode = f'Playing: {played_file}] [Alarm: {alarm_play_count // 60}:{alarm_play_count % 60}'
    system_message = f'[{play_mode}][V: {play_volume}]'
    b_html = b'<html>' \
             b'<head>' \
             b'<META http-equiv=\"refresh\" content=\"' + str(REFRESH_WEB_SECS).encode() + b';URL=/\">' \
                                                                                           b'</head>' \
                                                                                           b'<body>' \
                                                                                           b'<p style="font-size:40px; text-align: center">' \
             + system_message.encode() + \
             b'</p>' \
             b'<p style="font-size:80px; text-align: center"><a href="/play">Play</a> </p>' \
             b'<p style="font-size:80px; text-align: center"><a href="/alarm">Alarm</a> </p>' \
             b'<p style="font-size:80px; text-align: center"><a href="/trigger">Trigger</a> </p>' \
             b'<p style="font-size:80px; text-align: center"><a href="/stop">Stop</a> </p>' \
             b'<p style="font-size:80px; text-align: center"><a href="/vp">[V+]</a>   <a href="/vm">[V-]</a> </p>' \
             b'</body>' \
             b'</html>'
    return b_html



def flask_web_request_handler(path='', *args, **kwargs):
    data = request.data
    print(path, data)
    params = get_params(request.url)
    if path:
        queue.put(path)
    return create_web()



def map_urls():
    flask_app.add_url_rule(rule='/', endpoint='nothing', view_func=flask_web_request_handler, methods=['POST', 'GET', 'PUT', 'DELETE'])
    flask_app.add_url_rule(rule='/<path:path>', endpoint='allpath', view_func=flask_web_request_handler, methods=['POST', 'GET', 'PUT', 'DELETE'])



def get_local_addresses():
    addresses = [address_info[4][0] for address_info in socket.getaddrinfo(socket.gethostname(), None)
                 if address_info[0] == socket.AddressFamily.AF_INET]
    # addresses = [a for a in addresses if a[0:3] != '192' and a[0:3] != '127']
    return addresses



def process_func():
    addresses = get_local_addresses()
    flask_app.run(host=addresses[0], port=80, debug=False, threaded=True)



def start():
    global is_playing, is_alarming, alarm_play_count, ALARM_PLAY_TIME, play_volume, played_file
    while True:
        time.sleep(1)
        if not queue.empty():
            command = queue.get().upper()

            if command == 'PLAY':
                is_playing = True
                is_alarming = False
                alarm_play_count = 0
                played_file = ''
            if command == 'ALARM':
                is_playing = False
                is_alarming = True
                played_file = ''
            if command == 'STOP':
                is_playing = False
                is_alarming = False
                alarm_play_count = 0
                played_file = ''
                if mixer.music.get_busy():
                    mixer.music.stop()
            if command == 'TRIGGER':
                if is_alarming:
                    alarm_play_count = ALARM_PLAY_TIME
            if command == 'VP':
                play_volume += 1
                if play_volume > 10:
                    play_volume = 10
            if command == 'VM':
                play_volume -= 1
                if play_volume < 1:
                    play_volume = 1

        if is_playing:
            mixer.music.set_volume(play_volume / 10)
            if not mixer.music.get_busy():
                played_file = play_random_track(MUSIC_FOLDER)

        # if is_alarming:
        #     mixer.music.set_volume(play_volume / 10)
        #     if not mixer.music.get_busy():
        #         played_file = play_random_track(ALARM_FOLDER)

        if is_alarming:
            mixer.music.set_volume(play_volume / 10)
            if alarm_play_count > 0:
                alarm_play_count -= 1
                if not mixer.music.get_busy():
                    played_file = play_random_track(ALARM_FOLDER)
            else:
                mixer.music.stop()



def play_random_track(folder) -> str:
    file = select_random_file(folder)
    mixer.music.load(file)
    mixer.music.play()
    return file



def select_random_file(folder: str) -> str:
    files = get_all_files(folder)
    n = randint(0, len(files) - 1)
    # print(f'file n:{n} {files}')
    file = files[n]
    return file



def get_all_files(folder: str, file_list: list = None):
    if file_list is None:
        file_list = list()
    for root, folders, files in os.walk(folder):
        for file in files:
            if '.mp3' in file:
                file_list.append(os.path.join(root, file))
        for folder in folders:
            get_all_files(folder, file_list)
    return file_list



if __name__ == '__main__':
    mixer.init()
    seed(time.time())
    map_urls()
    Thread(target=process_func).start()
    start()
