//General Format
//db.collection.find({query filter parameters (WHERE)},{display key values(SELECT)})

//1.) Which states have zip codes with populations greater than (75,000) people?
db.zips.distinct("state", {"pop": {"$gt": 75000}})

//2.) Which cities have populations greater than 200,000 people?
db.zips.aggregate([{"$group": {"_id": "$city", "totalPop": {"$sum": "$pop"}}}, {"$match": {"totalPop": {"$gt": 200000}}}]).pretty()

//3.) What is the total population of each city in FL. Sort in ascending order based on total population?
db.zips.aggregate([{"$match": {"state": "FL"}}, {"$group": {"_id": "$city", "totalPop": {"$sum": "$pop"}}}, {"$sort": {"totalPop": 1}}]).pretty()

//4.) What are the 10 most populous cities in MO?
db.zips.aggregate([{"$match": {"state": "MO"}}, {"$group": {"_id": "$city", "totalPop": {"$sum": "$pop"}}}, {"$sort": {"totalPop": -1}}, {"$limit": 10}]).pretty()

//5.) What is the population of New York City, NY?
db.zips.aggregate([{"$match": {"city": "NEW YORK", "state": "NY"}}, {"$group": {"_id": "New York", "totalPop": {"$sum": "$pop"}}}]).pretty()

//6.) List the cities in Illinois that have 3 or more zip codes? Sort in descending order by total number of zip codes. Hint: count multiple occurrences of a city’s name.
db.zips.aggregate([{"$match": {"state": "IL"}}, {"$group": {"_id": "$city", "zipCount": {"$sum": 1}}}, {"$match": {"zipCount": {"$gte": 3}}}, {"$sort": {"zipCount": -1}}]).pretty()

//7.) Which state has the fewest number of zip codes?
db.zips.aggregate([{"$group": {"_id": "$state", "zipCount": {"$sum": 1}}}, {"$sort": {"zipCount": 1}}, {"$limit": 1}]).pretty()

//8.) What is the name and total population of the most populous city in the zips database?
db.zips.aggregate([{"$group": {"_id": "$city", "totalPop": {"$sum": "$pop"}}}, {"$sort": {"totalPop": -1}}, {"$limit": 1}]).pretty()

//9.) What is the name and total population of the least populous city in the zips database?
db.zips.aggregate([{"$group": {"_id": "$city", "totalPop": {"$sum": "$pop"}}}, {"$sort": {"totalPop": 1}}, {"$limit": 1}]).pretty()

//10.) What is the name and total population for the 15 most populous cities in the zips database?
db.zips.aggregate([{"$group": {"_id": "$city", "totalPop": {"$sum": "$pop"}}}, {"$sort": {"totalPop": -1}}, {"$limit": 15}]).pretty()

//11.) List the symbol and company name of the companies with the ten (10) highest stock price.
db.stocks.find({}, {"Symbol": 1, "Name": 1, "Price": 1}).sort({"Price": -1}).limit(10).pretty()

//12.) List total earnings (EBITDA) by sector.
db.stocks.aggregate([{"$group": {"_id": "$Sector", "totalEarnings": {"$sum": "$EBITDA"}}}]).pretty()

//13.) List the average earnings by sector
db.stocks.aggregate([{"$group": {"_id": "$Sector", "averageEarnings": {"$avg": "$EBITDA"}}}]).pretty()

//14.) Show the company name and symbol of the top 10 companies in earnings in the Industrials sector?
db.stocks.find({"Sector": "Industrials"}, {"Name": 1, "Symbol": 1, "EBITDA": 1}).sort({"EBITDA": -1}).limit(10).pretty()

//15.) List the names of the companies in the Information Technology sector that paid dividends to shareholders. You will know this if the “Dividend Yield” field is greater than 0.
db.stocks.find({"Sector": "Information Technology", "Dividend Yield": {"$gt": 0}}, {"Name": 1}).pretty()

//16.) What are the top 10 companies in the “Health Care” sector when it comes to “Earnings/Share”?
db.stocks.find({"Sector": "Health Care"}, {"Name": 1, "Symbol": 1, "Earnings/Share": 1}).sort({"Earnings/Share": -1}).limit(10).pretty()

//17.) Calculate the total earnings (EBITDA) for all companies in the Information Technology sector.
db.stocks.aggregate([{"$match": {"Sector": "Information Technology"}}, {"$group": {"_id": null, "totalEarnings": {"$sum": "$EBITDA"}}}]).pretty()

//18.) Calculate the number of outstanding shares for companies in the Industrials sector. Number of outstanding shares can be calculated by dividing the Market Cap by the Price. Display company name, symbol, and number of outstanding shares in ascending order.
db.stocks.aggregate([{"$match": {"Sector": "Industrials"}}, {"$project": {"Name": 1, "Symbol": 1, "OutstandingShares": {"$divide": ["$Market Cap", "$Price"]}}}, {"$sort": {"OutstandingShares": 1}}]).pretty()
