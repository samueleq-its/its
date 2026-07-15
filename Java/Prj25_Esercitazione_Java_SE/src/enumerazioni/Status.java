package enumerazioni;

public enum Status {
	ONLINE(true), BUSY(true), HIDDEN(false), OFFLINE(false);
	
	private boolean isVisible;
	
	private Status(boolean isVisible) {
		this.isVisible = isVisible;
	}

	public boolean canContact(Status s) {
		return this != Status.OFFLINE && s.isVisible();
	}

	public boolean isVisible() {
		return isVisible;
	}
	
	
}

