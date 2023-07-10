CREATE TABLE public."Images" (
    "Id" serial PRIMARY KEY,
    "BirthdayId" integer NOT NULL,
    "Img" bytea NOT NULL,
    FOREIGN KEY ("BirthdayId") REFERENCES public."Birthdays" ("Id") ON DELETE CASCADE
);
