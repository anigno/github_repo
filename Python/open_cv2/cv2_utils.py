import os
import cv2

def set_capture_res(cap, w, h):
    cap.set(3, w)
    cap.set(4, h)

def get_frame_dim(frame):
    return frame.shape[0], frame.shape[1]

# grab resolution dimensions and set video capture to it.
def get_dims(cap, res='1080p'):
    width, height = STD_DIMENSIONS["480p"]
    if res in STD_DIMENSIONS:
        width, height = STD_DIMENSIONS[res]
    # change the current caputre device
    # to the resulting resolution
    set_capture_res(cap, width, height)
    return width, height

def rescale_frame(frame, scale):
    dim = get_frame_dim(frame)
    dim = int(dim[1] * scale), int(dim[0] * scale)
    return cv2.resize(frame, dim, interpolation=cv2.INTER_AREA)

def to_gray(frame):
    return cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)

STD_DIMENSIONS = {
    "480p": (640, 480),
    "720p": (1280, 720),
    "1080p": (1920, 1080),
    "4k": (3840, 2160),
}

VIDEO_TYPE = {
    'avi': cv2.VideoWriter_fourcc(*'XVID'),
    # 'mp4': cv2.VideoWriter_fourcc(*'H264'),
    'mp4': cv2.VideoWriter_fourcc(*'XVID'),
}

def get_video_type(filename):
    filename, ext = os.path.splitext(filename)
    if ext in VIDEO_TYPE:
        return VIDEO_TYPE[ext]
    return VIDEO_TYPE['avi']
