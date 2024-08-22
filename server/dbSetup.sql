CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE recipes(
  id INT NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(255) NOT NULL,
  instructions VARCHAR(5000) NOT NULL,VARCHAR(255) NOT NULL,
  img VARCHAR(1000) NOT NULL,
category ENUM("breakfast", "lunch", "dinner", "snack","dessert") NOT NULL,
creatorId VARCHAR(255) NOT NULL,
FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
)

DROP TABLE ingredients


CREATE TABLE ingredients (
id INT NOT NULL primary key AUTO_INCREMENT,
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
name VARCHAR(255) NOT NULL,
quantity VARCHAR(255) NOT NULL,
recipeId INT NOT NULL,
FOREIGN KEY (recipeId) REFERENCES recipes  (id) ON DELETE CASCADE
);


CREATE TABLE favorites (
id INT NOT NULL primary key AUTO_INCREMENT,
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
recipeId INT NOT NULL,
accountId VARCHAR(255) NOT NULL,
FOREIGN KEY (recipeId) REFERENCES recipes (id) ON DELETE CASCADE,
FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE
);


    SELECT favorites.*, accounts.*
    FROM favorites
    JOIN accounts ON accounts.id = favorites.accountId
    WHERE 
    favorites.id =1;



    SELECT recipes.*, accounts.*, favorites.*
    FROM favorites
    JOIN recipes ON recipes.id = favorites.recipeId
    JOIN accounts ON accounts.id = recipes.id
    WHERE favorites.accountId = @userId;