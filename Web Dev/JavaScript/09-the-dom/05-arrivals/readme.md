# 5.Arrivals
## Author
samuele.querio@edu-its.it

## Requirements
- Implement the arrivals page of an airport such as [this one](https://www.aeroportoditorino.it/en/tofly/flights/departs-arrivals)
	- Create a complete proper webpage with a title, description and all other HTML tags
	- Add Javascript and CSS files
	- Include as much detail as you can to each flight row
	- Add a Status to each flight. Status can be DEPARTING, DELAYED, ON_TIME, ARRIVED, etc
- Simulate a real arrivals list
	- The list should start empty and update every 10 seconds
	- Flights that have arrived should be removed after 60 seconds
	- Flights should change status in time. E.g. departing>on_time>delayed>arrived
	- Flights that are delayed should be displayed in red
	- New flights should be added to the bottom of the list
	- The list should be sorted by date and hour

## Approach to solution

Initially I've made a function to create the table with all the data and a second function to update the necessary fields, I've then refactored the code to generate the table from scratch at each update, which requires simpler logic and should follow a single source of truth approach
