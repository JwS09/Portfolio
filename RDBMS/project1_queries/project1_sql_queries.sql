docker exec -it mysql-container bash

cd ~/sql-files/universityDB/

mysql -u root -p

source ~/sql-files/universityDB/01_lookup_tables.sql

source ~/sql-files/universityDB/02_university.sql

source ~/sql-files/universityDB/03_university_year.sql

source ~/sql-files/universityDB/04_university_ranking_year.sql

SHOW databases;
USE universities;
DESCRIBE country;
DESCRIBE ranking_criteria;
DESCRIBE ranking_system;
DESCRIBE university;
DESCRIBE university_ranking_year;
DESCRIBE university_year;


--How many universities in each country? Display the country name and number of universities in a column named "Number of Universities". Display results in descending order based on the number of universities. (74 rows returned). The results show the first 10 rows and last 10 rows of the results.
SELECT country_name, COUNT(u.id) AS "Number of Universities"
FROM country c, university u
WHERE c.id = u.country_id
GROUP BY c.id
ORDER BY COUNT(u.id) DESC;

--List all of the current universities in the database. List the university name and country (1247 rows returned)
SELECT u.university_name, c.country_name
FROM university u, country c
WHERE u.country_id = c.id
ORDER BY u.university_name;

--Show the average university student enrollment for each country in the database in 2015. Display the country and average enrollment in a column named "Average enrollment". Round to 0 decimal places and order by the average number of students.
SELECT c.country_name, ROUND(AVG(uy.num_students), 0) AS "Average enrollment"
FROM country c, university u, university_year uy
WHERE c.id = u.country_id AND u.id = uy.university_id AND uy.year = 2015
GROUP BY c.id
ORDER BY AVG(uy.num_students) DESC;

--How many ranking criteria does each ranking system have? Display the ranking system name and number of criteria in a column named "Total Criteria". Display in descending order by total criteria.
SELECT rs.system_name, COUNT(rc.id) AS "Total Criteria"
FROM ranking_system rs, ranking_criteria rc
WHERE rs.id = rc.ranking_system_id
GROUP BY rs.id
ORDER BY COUNT(rc.id) DESC;

--Show the average score for each ranking criteria in the year 2014. Display the system name, criteria name and average score in a column named average score. Round the average scores to 2 decimal places. Display results in aescending order by ranking system name. Hint: you will have to group by two columns. Hint Hint group by the columns you ant displayed.
SELECT rs.system_name, rc.criteria_name, ROUND(AVG(ury.score), 2) AS "Average Score"
FROM ranking_system rs, ranking_criteria rc, university_ranking_year ury
WHERE rs.id = rc.ranking_system_id AND rc.id = ury.ranking_criteria_id AND ury.year = 2014
GROUP BY rc.id
ORDER BY rs.system_name ASC, rc.criteria_name ASC;

--Show the top 25 universities with the highest alumni employment rank in 2015. Display in Descending order
SELECT u.university_name, rc.criteria_name, ury.score
FROM university u, ranking_criteria rc, university_ranking_year ury
WHERE u.id = ury.university_id AND rc.id = ury.ranking_criteria_id AND rc.criteria_name = "Alumni Employment Rank" AND ury.year = 2015
ORDER BY ury.score DESC
LIMIT 25;

--Show the number of international students at each United States universities in 2013. Show the University name and the number of students in a column called "Total Internalional Students". Display in descending order by total students. You can calculate the number of international students by (pct_international_students * 0.01) * num students. (75 rows returned). The results below show the first 10 rows and the last 10 rows.
SELECT u.university_name, ROUND((uy.pct_international_students * 0.01) * uy.num_students) AS "Total International Students"
FROM country c, university u, university_year uy
WHERE c.id = u.country_id AND u.id = uy.university_id AND c.country_name = "United States of America" AND uy.year = 2013
ORDER BY ROUND((uy.pct_international_students * 0.01) * uy.num_students) DESC;

--Show the number of students in each country in 2016. Display the contry name and number of students in a column called "Total Students" ordered by the number of students in descending order.
SELECT c.country_name, SUM(uy.num_students) AS "Total Students"
FROM country c, university u, university_year uy
WHERE c.id = u.country_id AND u.id = uy.university_id AND uy.year = 2016
GROUP BY c.id
ORDER BY SUM(uy.num_students) DESC;
