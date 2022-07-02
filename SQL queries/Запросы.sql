--Получить контент, отсортированный по убыванию рейтинга (среднее от оценок пользователей. Если оценок нет, то среднее – 0).
SELECT c.Id, c.Name, c.Category, c.DateTimeUtc,
	(CASE WHEN AVG(rate) IS NOT NULL THEN 
		AVG(rate)
	ELSE 
		0 
	END) AS "Рейтинг" 
FROM Content AS c
LEFT JOIN ContentRating AS cr ON c.Id = cr.ContentId
GROUP BY c.Id, c.Name, c.Category, c.DateTimeUtc
ORDER BY "Рейтинг" DESC;

--Получить пользователей, отсортированных по убыванию рейтинга (рейтинг пользователя – средний рейтинг созданного им контента).
SELECT u.Email, COALESCE(AVG(rate), 0) AS "Рейтинг"
FROM User AS u
LEFT JOIN Content AS c ON u.Id = c.CreatorId 
LEFT JOIN ContentRating AS cr ON c.Id = cr.ContentId
GROUP BY u.Email
ORDER BY Рейтинг DESC

--Получить все оценки видео всеми пользователями. Если оценки нет, то считать, что оценка – 0.
SELECT c.Id, c.Name, COALESCE(rate, 0) AS "Рейтинг"
FROM Content AS c
LEFT JOIN ContentRating AS cr ON c.Id = cr.ContentId
WHERE c.Category = 2