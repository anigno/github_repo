# https://www.devdungeon.com/content/read-and-send-email-python
import imaplib
import email
import traceback
from smtplib import SMTP_SSL, SMTP_SSL_PORT

from typing import Iterable

ORG_EMAIL = "@gmail.com"
LOGIN_EMAIL = "anigno" + ORG_EMAIL
PWD = "matqemezvduyciei"
SMTP_SERVER = "imap.gmail.com"
SMTP_PORT = 993

def read_email_from_gmail() -> Iterable[str]:
    ret = []
    try:
        mail = imaplib.IMAP4_SSL(SMTP_SERVER)
        mail.login(LOGIN_EMAIL, PWD)
        mail.select('[Gmail]/Spam')
        data = mail.search(None, 'ALL')
        mail_ids = data[1]
        id_list = mail_ids[0].split()
        if not id_list:
            print('No spam emails')
            return []
        first_email_id = int(id_list[0])
        latest_email_id = int(id_list[-1])

        for i, email_id in enumerate(range(latest_email_id, first_email_id - 1, -1), start=0):
            data = mail.fetch(str(email_id), '(RFC822)')
            for response_part in data:
                arr = response_part[0]
                if isinstance(arr, tuple):
                    msg = email.message_from_string(str(arr[1], 'utf-8'))
                    email_subject = msg['subject']
                    email_from = msg['from']
                    print(f'{i} [{email_from}] [{email_subject}]')
                    ret.append(email_from)

    except Exception as e:
        traceback.print_exc()
        print(str(e))
    return ret

def extract_string(s: str, start: str, end: str):
    a = s.index(start, 0)
    b = s.index(end, a)
    return s[a+1:b]


def send_emails(spam_emails):
    for i, email in enumerate(spam_emails, start=0):
        print(f'{i} {email}')
        email=extract_string(email,'<','>')
        from_email = 'My name <someone@example.com>'  # or simply the email address
        body = "ok, great"
        headers = f"From: {from_email}\r\n"
        headers += f"To: {', '.join(email)}\r\n"
        headers += f"Subject: thanks you\r\n"
        # email_message = headers + "\r\n" + body  # Blank line needed between headers and body
        email_message = body

        # Connect, authenticate, and send mail
        smtp_server = SMTP_SSL(SMTP_SERVER, port=SMTP_SSL_PORT)
        # smtp_server.set_debuglevel(1)  # Show SMTP server interactions
        smtp_server.login(LOGIN_EMAIL, PWD)
        smtp_server.sendmail(from_email, email, email_message)
        # Disconnect
        smtp_server.quit()

if __name__ == '__main__':
    spam_emails = read_email_from_gmail()
    # print(spam_emails)
    send_emails(spam_emails)
