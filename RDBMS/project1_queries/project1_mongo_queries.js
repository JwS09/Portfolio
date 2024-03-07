
//How many products does the vendor "Highway 66 Mini Classics" produce in the database { "Total Products" : 9 }
db.classicmodels.find({"productVendor": "Highway 66 Mini Classics"}, {"productName": 1}).count()

//Calculate the number of orders each customer has placed and display the top 15 in descending order based on orders placed. Display the customer name and the orders placed in a columns called “OrdersPlaced” in descending order by orders placed.
db.classicmodels.aggregate([
    {$match: {"type": "order"}},
    {$group: {_id: "$customerName", OrdersPlaced: {$sum: 1}}},
    {$sort: {OrdersPlaced: -1}},
    {$limit: 15}
  ])
  
//List the product names, MSRP, and quantity in stock for products where the MSRP is greater than or equal to 150. Sort in descending order by quantity in stock.
db.classicmodels.find({"MSRP": {$gte: 150}, "type": "product"}, {"productName": 1, "quantityInStock": 1, "MSRP": 1}).sort({"quantityInStock": -1})

//Calculate and display the number of customers in each country. Display the country and number of customers in each country in a column called “totalCustomers”. Sort the results by the Number of Customers in each country.
db.classicmodels.aggregate([
    {$group: {_id: "$country", totalCustomers: {$sum: 1}}},
    {$sort: {totalCustomers: -1}}
  ])
  
//Which employees manage the most people? Develop a query to calculate the number of people each employees manages. Display the employee name and number of employees employees they manage in a column called “Number of Reports”.
db.classicmodels.aggregate([
    {$match: {"type": "employee"}},
    {$group: {_id: "$reportsTo", NumberOfReports: {$sum: 1}}},
    {$lookup: {from: "classicmodels", localField: "_id", foreignField: "_id", as: "managerInfo"}},
    {$unwind: "$managerInfo"},
    {$project: {_id: "$managerInfo.firstName", NumberOfReports: 1}}
  ])
  
//List the names and credit limit of the customers with the 8 highest credit limits in France. Display in descending order by credit limit.
db.classicmodels.find({"country": "France", "type": "customer"}, {"customerName": 1, "creditLimit": 1}).sort({"creditLimit": -1}).limit(8)

//Write a query to calculate the number of product vebdors in the database. Display the result in a column called “Number of Vendors.
db.classicmodels.distinct("productVendor", {"type": "product"}).length

//Calculate the dollar value of each product in inventory. You can calculate this by multiplying the quantity in stock by the buy price. Display the product name, quantity in stock, buy price, and in its dollar value in a column called “Dollar Value”. Sort the results in descending order based on dollar value. The results show the first 5 and last  5 results.
db.classicmodels.aggregate([
    {$match: {"type": "product"}},
    {$project: {
      productName: 1, 
      quantityInStock: 1, 
      buyPrice: 1, 
      "DollarValue": {$multiply: ["$quantityInStock", "$buyPrice"]}
    }},
    {$sort: {DollarValue: -1}}
  ])
  