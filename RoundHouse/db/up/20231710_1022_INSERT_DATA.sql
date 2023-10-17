IF(NOT EXISTS(SELECT 1 FROM dbo.Tags))
BEGIN
	INSERT INTO Tags (Name)
	VALUES ('tag1'), ('tag2')
END

IF(NOT EXISTS(SELECT 1 FROM dbo.Authors))
BEGIN
	INSERT INTO Authors(Name)
	VALUES ('Author1'), ('Author2')
END

IF(NOT EXISTS(SELECT 1 FROM dbo.BlogPosts))
BEGIN
	INSERT INTO BlogPosts(Title, TextBody, AuthorId)
	VALUES ('Blogi', 'Blogi Teksti', 1), ('Blogi2', 'Blogi Teksti 2', 2)
END

IF(NOT EXISTS(SELECT 1 FROM dbo.BlogPostTag))
BEGIN
	INSERT INTO BlogPostTag(PostsId, TagsId)
	VALUES (1, 1), (1, 2), (2,1)
END
