CREATE TABLE IF NOT EXISTS quest(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
  title VARCHAR(255) NOT NULL COMMENT 'title',
  description VARCHAR(255) COMMENT 'description',
  reward int DEFAULT 0 COMMENT 'reward',
  completed TINYINT COMMENT 'completed'
) DEFAULT charset utf8 COMMENT '';
CREATE TABLE if NOT EXISTS knight(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
  name VARCHAR(255) NOT NULL COMMENT 'name',
  homeCastle VARCHAR(255) COMMENT 'home castle',
  questsCompleted int DEFAULT 0 COMMENT 'total quests completed',
  gold int DEFAULT 0 COMMENT 'gold',
  questId int COMMENT 'current quest'
) DEFAULT charset utf8 COMMENT '';