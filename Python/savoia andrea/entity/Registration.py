# Simple entity representing a registration.
class Registration:
    def __init__(self, id, data, user_id, course_id):
        self.id = id
        self.data = data
        self.user_id = user_id
        self.course_id = course_id