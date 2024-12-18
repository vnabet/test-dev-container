IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'VincentDB')
BEGIN
    CREATE DATABASE VincentDB;

    USE VincentDB;

    CREATE TABLE table_test
    (
        id INT IDENTITY
            CONSTRAINT table_test_pk
                PRIMARY KEY,
        name VARCHAR(255) NOT NULL
    );

    INSERT INTO table_test (name)
    VALUES ('tutu'), ('tata'), ('toto'), ('titi');
END
GO
