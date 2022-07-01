--Получить контент, отсортированный по убыванию рейтинга (среднее от оценок пользователей. Если оценок нет, то среднее – 0).
SELECT Content.name, IF(AVG(rate) IS NOT NULL, AVG(rate), 0) AS "Рейтинг" FROM Content
	LEFT JOIN Article ON Content.Id = Article.ContentId
	LEFT JOIN Video ON Content.Id = Video.ContentId
	LEFT JOIN Gallery ON Content.Id = Gallery.ContentId
	JOIN ContentRating ON Content.Id = ContentRating.ContentId
GROUP BY Content.name
ORDER BY "Рейтинг" DESC