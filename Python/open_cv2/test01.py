import cv2

from cv2_utils import rescale_frame, to_gray, set_capture_res, VIDEO_TYPE

cap = cv2.VideoCapture(0)
set_capture_res(cap, 640, 480)
video_writer = cv2.VideoWriter("capture.avi", VIDEO_TYPE['avi'], 25, (640, 480))

while True:
    ret, frame = cap.read()
    gray_frame = to_gray(frame)
    gray_frame = rescale_frame(gray_frame, 0.5)
    video_writer.write(frame)
    cv2.imshow('frame1', frame)
    cv2.imshow('frame2', gray_frame)

    if cv2.waitKey(20) & 0xFF == ord('q'):
        break
cap.release()
cv2.destroyAllWindows()
