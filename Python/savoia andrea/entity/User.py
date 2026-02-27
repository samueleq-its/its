# Simple entity representing a user.
class User:
    def __init__(self, id, name, lastname, subscription_state):
        self.id = id
        self.name = name
        self.lastname = lastname
        self.subscription_state = subscription_state

    def __str__(self):
        return (
            f"User(id: {self.id}, name: {self.name}, lastname: {self.lastname}, "
            f"subscription_state: {self.subscription_state})"
        )