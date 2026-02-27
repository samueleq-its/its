# Simple entity representing a course.
class Course:
    def __init__(self, id, name, busy_places, max_places):
        self.id = id
        self.name = name
        self.busy_places = busy_places
        self.max_places = max_places

    def __str__(self):
        return (
            f"Course(id: {self.id}, name: {self.name}, busy places: {self.busy_places}, "
            f"max places: {self.max_places})"
        )