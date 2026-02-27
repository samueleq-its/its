from repository.UserRepository import *
from repository.RegistrationRepository import *
from repository.CourseRepository import *
from entity.User import *

# Service layer: input validation and coordination with the repository.
class UserService:
    def __init__(self):
        self.userRepository = UserRepository()
        self.registrationRepository = RegistrationRepository()
        self.courseRepository = CourseRepository()

    def save_user(self, name, lastname):
        # Normalize and validate inputs before saving.
        name = name.lower().strip()
        lastname = lastname.lower().strip()
        if not name : return "User Name cannot be empty"
        if not lastname : return "Lastname cannot be empty"

        # Creo un instanza di user
        user = User(None, name, lastname, True)
        # Salvo l'utente
        if self.userRepository.save(user) == 0:
            return "error saving user"

        return "user saved"

    def find_all_users(self):
        # Delegate listing to the repository.
        users = self.userRepository.find_all_users()
        return users

    def find_user_by_id(self, id):
        # Validate and parse the id before querying.
        if not id : return "User ID cannot be empty"
        try:
            id = int(id)
        except:
            return "User ID must be a integer"
        user = self.userRepository.find_user_by_id(id)
        if not user: return "User not found"
        return user

    def update_subscription_state(self, id_user):
        # Toggle subscription state for the specified user.
        user = self.userRepository.find_user_by_id(id_user)
        if not user: return "User not found"
        if not self.userRepository.update_subscription_state(not user.subscription_state, user.id):
            return "User subscription state not updated"
        return "User subscription state updated"

    def delete_user(self, id_user):
        if not id : return "User ID cannot be empty"
        try:
            id_user = int(id_user)
        except:
            return "User ID must be a integer"
        user = self.userRepository.find_user_by_id(id_user)
        if not user: return "User not found"

        list_registration = self.registrationRepository.find_all_by_user_id(user)
        # se la lista non è vuota aggiorna i posti occupati per ogni registrazione cancellata
        if list_registration:
            # rimuovere dai posti occupati l'utente
            for registration in list_registration:
                self.courseRepository.update_busy_places(registration.course_id,-1)
            # cancellare tutte le iscirizoni dell'utente
            if not self.registrationRepository.delete_by_user_id(user):
                return "registration deleted error"

        if not self.userRepository.delete_user_by_id(user):
            return "User deleted error"

        return "User deleted"