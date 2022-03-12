import smtplib
import ssl

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
    server.sendmail(from_email, [to_email,to_email], message)
    server.quit()
