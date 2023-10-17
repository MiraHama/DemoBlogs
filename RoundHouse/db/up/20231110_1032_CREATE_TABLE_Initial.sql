IF OBJECT_ID(N'dbo.Authors') IS NULL
CREATE TABLE Authors (
Id INT NOT NULL IDENTITY,
Name nvarchar(50) NOT NULL,
CONSTRAINT PK_authors PRIMARY KEY (Id)
)

IF OBJECT_ID(N'dbo.BlogPosts') IS NULL
CREATE TABLE BlogPosts (
Id INT NOT NULL IDENTITY,
Title nvarchar(50) NOT NULL,
TextBody nvarchar(max),
AuthorId INT NOT NULL,
CONSTRAINT PK_BlogPosts PRIMARY KEY (Id),
CONSTRAINT FK_BlogPosts_Authors_AuthorId FOREIGN KEY (AuthorId) REFERENCES Authors (Id) ON DELETE CASCADE
);

IF OBJECT_ID(N'dbo.Tags') IS NULL
CREATE TABLE Tags (
Id INT NOT NULL IDENTITY,
Name nvarchar(20) NOT NULL,
CONSTRAINT PK_Tags PRIMARY KEY (Id)
);

IF OBJECT_ID(N'dbo.BlogPostTag') IS NULL
CREATE TABLE BlogPostTag (
Id INT NOT NULL IDENTITY,
PostsId INT NOT NULL,
TagsId INT NOT NULL,
CONSTRAINT PK_BlogPostTag PRIMARY KEY (Id),
CONSTRAINT FK_BlogPostTag_BlogPosts_PostsId FOREIGN KEY (PostsId) REFERENCES BlogPosts (Id) ON DELETE CASCADE,
CONSTRAINT FK_BlogPostTag_Tags_TagsId FOREIGN KEY (TagsId) REFERENCES Tags (Id) ON DELETE CASCADE
);
