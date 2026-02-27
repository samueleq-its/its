from repository.RegistrationRepository import *
from entity.Registration import *
from repository.CourseRepository import *
from repository.UserRepository import *
from datetime import *

class RegistrationService:
    def __init__(self):
        self.registrationRepository = RegistrationRepository()
        self.courseRepository = CourseRepository()
        self.userRepository = UserRepository()

    def save_registration(self, user_id, course_name):
        # normalizzo l'input
        course_name = course_name.lower().strip()
        user_id = user_id.strip()
        if not course_name: "name is required"
        if not user_id: "places is required"
        try:
            user_id = int(user_id)
        except:
            return "user_id must be an integer"
        # recupero il corso
        course = self.courseRepository.find_course_by_name(course_name)
        if not course: return "course does not exist"
        # recupero l'utente
        user = self.userRepository.find_user_by_id(user_id)
        if not user: return "user does not exist"
        # controllo che l'utente sia abbonato
        if not user.subscription_state: return "user subscription state is invalid"
        # controllo se nel corso c'è ancora posto
        if course.busy_places == course.max_places: return "course no free places"
        # controllo se l'utente non sia già registrato al corso
        if self.registrationRepository.exists_registration_by_user_id_and_course_id(user,course):
            return "user already registered"
        current_date = datetime.now().strftime("%Y-%m-%d")
        registration = Registration(None, current_date, user.id, course.id)
        # salvo la registrazione
        if not self.registrationRepository.save(registration):
            return "registration save failed"
        # aggiorno i posti occupati
        self.courseRepository.update_busy_places(registration.course_id, 1)

        return "saved registration successfully"

    def delete_registration(self, registration_id):
        # normalizzato
        registration_id = registration_id.strip()
        if not registration_id: "places is required"
        try:
            registration_id = int(registration_id)
        except:
            return "registration_id must be an integer"
        # recupero la registrazione
        registration = self.registrationRepository.find_registration_by_id(registration_id)
        if not registration: return "registration does not exist"
        # cancello la registrazione
        if not self.registrationRepository.delete_registration(registration):
            return "registration delete failed"
        # aggiorno i posti occupati riducendoli
        self.courseRepository.update_busy_places(registration.course_id, -1)
        return "deleted registration successfully"

    def find_all_registrations(self):
        registrations = self.registrationRepository.find_all_registrations()
        return registrations