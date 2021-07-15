CREATE TABLE IF NOT EXIST quest(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
  title varchar(255) COMMENT 'title',
  description VARCHAR(255) COMMENT 'description',
  reward int COMMENT 'reward',
  completed BIT COMMENT 'completed'
) DEFAULT charset utf8 COMMENT '';
CREATE TABLE if NOT exist knight(
  id int NOT NULL PRIMARY KEY COMMENT 'primary key',
  name varchar(255) NOT NULL COMMENT 'name',
  homeCastle VARCHAR(255) COMMENT 'home castle',
  questCompleted int COMMENT 'total quests completed',
  gold int COMMENT 'gold' questId int COMMENT 'FK: currest quest',
  FOREIGN KEY (questId) REFERENCES quest(id)
) DEFAULT charset utf8 COMMENT '';