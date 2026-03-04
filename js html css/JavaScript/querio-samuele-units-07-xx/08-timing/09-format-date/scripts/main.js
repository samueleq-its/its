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
	const ONE_MINUTE = 60000;
	const ONE_HOUR = 3600000;

	let deltaTime = Date.now() - date.getTime();

	if (deltaTime < ONE_SECOND) {			// less than a second passesd
		console.log("right now");
	} else if (deltaTime < ONE_MINUTE) {	// less than a minute passed
		console.log(`${(deltaTime / ONE_SECOND).toFixed(0)} sec. ago`);
	} else if (deltaTime < ONE_HOUR) {		// less than an hour passed
		console.log(`${(deltaTime / ONE_MINUTE).toFixed(0)} min. ago`);
	} else { 									// more than an hour passed
		//DD.MM.YY HH:mm
		let day = date.getDate().toString().padStart(2, '0');
		let month = (date.getMonth() + 1).toString().padStart(2, '0');
		let year = date.getFullYear();
		let hours = date.getHours().toString().padStart(2,'0');
		let minutes = date.getMinutes().toString().padStart(2,'0');
		console.log(`${day}.${month}.${year} ${hours}:${minutes}`);
	}
}

formatDate(new Date());
formatDate(new Date(Date.now() - 15000));	// 15 seconds ago
formatDate(new Date(Date.now() - 1200000));	// 20 minutes ago
formatDate(new Date(Date.now() - 6000000)); // 1h 30min ago
