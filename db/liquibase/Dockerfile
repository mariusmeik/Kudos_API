FROM liquibase/liquibase

RUN mkdir ./changelogs/

COPY ./changelogs/ ./changelogs/
COPY db.changelog-root.xml .
COPY liquibase.properties .

RUN lpm add postgresql --global

CMD liquibase update