/**
 * @file: main.js
 * @author: samuele.querio@edu-its.it
 * Purpose of file
 *
 * Detailed explanation of what the file does
 * on multiple lines
 */

/**
 * 
 * @param {Date} date 
 */
function formatDate(date) {
	const ONE_SECOND = 1000;
	const ONE_MINUTE = 60_000;
	const ONE_HOUR = 3_600_000;
	let now = Date.now();
	let dateTime = date.getTime();
	if (now - dateTime < ONE_SECOND) {			// less than a second passesd
		console.log("right now");
	} else if (now - dateTime < ONE_MINUTE) {	// less than a minute passed
		console.log(`${} sec. ago`);
	} else if (now - dateTime < ONE_HOUR) {		// less than an hour passed
		console.log(`${} min. ago`);
	} else { 									// more than an hour passed
		//DD.MM.YY HH:mm
	}
}