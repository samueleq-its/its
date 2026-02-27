from repository.CourseRepository import *
from repository.RegistrationRepository import *
from entity.Course import Course

class CourseService:
    def __init__(self):
        self.courseRepository = CourseRepository()
        self.registrationRepository = RegistrationRepository()

    def save_course(self, name, max_places):
        # normalizzo input
        name = name.lower().strip()
        max_places = max_places.strip()
        if not name: "name is required"
        if not max_places: "places is required"
        try:
            max_places = int(max_places)
        except:
            return "places must be an integer"
        # controllo se i posti massimi inserito sia superiore a 0
        if max_places <= 0: return "places must be > 0"
        course = Course(None, name, 0, max_places)
        # salvo il corso
        if self.courseRepository.save(course) == 0:
            return "error saving course"
        return "course saved"

    def update_max_places(self, course_name, new_max_places):
        # nromalizzo l'input
        course_name = course_name.strip()
        new_max_places = new_max_places.strip()
        if not course_name: return "course_name is required"
        if not new_max_places: return "new_places is required"
        try:
            new_max_places = int(new_max_places)
        except:
            return "new_places or course_id must be an integer"
        # controllo che i posti massimi diano superiori a 0
        if new_max_places <= 0: return "new_places must be > 0"
        # recupero il corso
        course = self.courseRepository.find_course_by_name(course_name)
        if not course: return "course not found"
        # controllo il valore dei posti occupati del corso se superiore al nuovo valore di posti massimi va in errore
        if self.courseRepository.find_busy_places(course) > new_max_places:
            return "max places exceeded user inscription"
        # aggiorno il valore di posti massimi
        if not self.courseRepository.update_max_places(course, new_max_places):
            return "error updating places"
        return "course places updated"

    def find_all_courses(self):
        courses = self.courseRepository.find_all_courses()
        return courses

    def find_course_by_name(self, course_name):
        course_name = course_name.strip()
        if not course_name: return "course_name is required"
        course = self.courseRepository.find_course_by_name(course_name)
        if not course: return "Course not found"
        return course

    def delete_course(self, course_name):
        course_name = course_name.strip()
        # recupero il corso
        course = self.courseRepository.find_course_by_name(course_name)
        if not course: return "course not found"
        # cancello il corso
        if not self.courseRepository.delete_course(course):
            return "error deleting course"
        # cancello le registrazioni associate al corso
        if not self.registrationRepository.delete_by_course(course):
            return "error deleting registrantions"
        return "course deleted"