import smtplib
import ssl
from email.mime.text import MIMEText

port = 465  # For SSL
login_email = "anigno.spam@gmail.com"
from_email = "any_name@gmail.com"
to_email = "anigno.spam@gmail.com"
password = 'aronanigno136'

context = ssl.create_default_context()

with smtplib.SMTP_SSL("smtp.gmail.com", port, context=context) as server:
    subject = 'subject'
    text = 'message text'
    message = f'Subject: {subject}\n\n{text}'

    server.login(login_email, password)

    msg = MIMEText("""body""")

    recipients = [
        "alimsende12@gmail.com",
        "inboxsend0000@gmail.com",
        "inboxsend6587@gmail.com",
        "sendinbox4545@gmail.com",
        "important@banko.ru.com",
        "favortastes@gmail.com",
        "boxofferdaily@gmail.com",
        "livescores010@gmail.com",
        "intermailflow@gmail.com",
        "endedge@hotmail.com",
        "dancetouch@hotmail.com",
        "sendprofit@yahoo.com",
        "limitesea@yahoo.com",
        "mailsspeed@aol.com",
        "pianopromo@aol.com",
        "deviceservice@aol.com",
        "1only4you@mail.ru",
        "feedback@99cent.org.uk",
        "recommendations@verified.com.de",
        "newsletter@selfcare.eu.com",
        "support@oszu.co.uk",
        "newsletter@benifs.com",
        "sol@sweetsfall.com",
        "clients@buffzy.com",
        "marketslot.us@gmail.com",
        "usefultoolstoday@gmail.com",
        "notificom@gmail.com",
        "fierverifier@gmail.com",
        "centertrending@gmail.com",
        "thecyberdot@gmail.com",
        "dexontechno@gmail.com"]
    recipients.append(from_email)

    msg['Subject'] = "subject line"
    msg['From'] = from_email
    msg['To'] = ", ".join(recipients)
    server.sendmail(from_email, to_email, msg.as_string())

    server.quit()
"""
regex from: ___NAME @ company.com to "NAME@company.com",

_*(.*)( )@( )(.*)
"$1@$4",

"""
