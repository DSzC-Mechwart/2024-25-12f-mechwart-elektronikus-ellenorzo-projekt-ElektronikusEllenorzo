CREATE DATABASE rotring DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;

CREATE TABLE tanulo (
    nev VARCHAR(50),
    szulHely VARCHAR(50),
    szulIdo DATE,
    anyjanev VARCHAR(50),
    lakcim VARCHAR(50),
    beirIdo DATE,
    szak VARCHAR(50),
    osztaly VARCHAR(10),
    kolise INT(1),
    koli VARCHAR(50),
    naploszam INT(8),
    torzsszam INT(8),
    matek VARCHAR(100),
    irodalom VARCHAR(100),
    nyelvtan VARCHAR(100),
    idegennyelv VARCHAR(100),
    tesi VARCHAR(100),
    fizika VARCHAR(100),
    szakma VARCHAR(100);
    );
    
CREATE Table tantargyak (
    tantargy VARCHAR(50),
    evfolyam VARCHAR(20),
    koz_szak VARCHAR(50),
    hetiora INT(8),
    evesora INT(10);
);

INSERT INTO tanulo (nev, szulHely, szulIdo, anyjanev, lakcim, beirIdo, szak, osztaly, kolise, koli, naploszam, torzsszam, matek, irodalom, nyelvtan, idegennyelv, tesi, fizika, szakma) VALUES
("Horváth Dániel", "Debrecen", "2009-11-25", "Horváthné Kiss Margit", "Debrecen Böszörményi út 22.", "2024-08-10", "infó", "9.B", 0, "", 38374338, 02150786, "3,5,4,5", "2,2,3,4", "3,2,4,3", "4,4,3,4", "5,5,5,5", "4,4,5,4", "5,5,3,5"),
("Sárközi Xavierka", "Debrecen", "2008-12-12", "Kanalas Tifani", "Hajdúhadház Rákóczi utca 45.", "2024-08-15", "gépész", "9.D", 1, "Gulyás Pál Kollégium", 95695425, 07265489, "3,2,3,1", "2,2,3,1", "3,2,1,3", "4,2,3,4", "5,5,5,5", "4,3,5,4", "5,2,3,4");

INSERT INTO tantargyak (tantargy, evfolyam, koz_szak, hetiora, evesora) VALUES
("matematika", "9-11", "közismereti", 4, 144),
("irodalom", "12", "közismereti", 3, 93),
("Adatbázis kezelés", "12", "szakmai", 2, 72),
("Backend fejlesztés", "13", "szakmai", 4, 124);