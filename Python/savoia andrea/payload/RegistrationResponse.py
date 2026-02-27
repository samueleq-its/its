class RegistrationResponse:
    def __init__(self, registration_id, data, user_name, user_lastname, user_subscription_state, courses_name):
        self.registration_id = registration_id
        self.data = data
        self.user_name = user_name
        self.user_lastname = user_lastname
        self.user_subscription_state = user_subscription_state
        self.courses_name = courses_name

    def __str__(self):
        return (
            f"Registration(registration_id: {self.registration_id}, data: {self.data}, "
            f"user_name: {self.user_name}, user_lastname: {self.user_lastname}, "
            f"user_subscription_state: {self.user_subscription_state}, courses_nam: {self.courses_name})"
        )