USE Geography

--22. All mountain peaks
SELECT
	PeakName
FROM
	Peaks ORDER BY PeakName

--23. Biggest countires by population
SELECT TOP(30)
	CountryName,
	[Population]	
FROM
	Countries
WHERE 
	ContinentCode = 'EU'
ORDER BY [Population] DESC, CountryName ASC

--24. Countries and currency
SELECT
	CountryName,
	CountryCode,
	CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS Currency
FROM
	Countries ORDER BY CountryName
