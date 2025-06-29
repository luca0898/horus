CREATE TABLE drone_telemetries (
    drone_id VARCHAR(100) NOT NULL,
    timestamp TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    battery INTEGER NOT NULL CHECK (battery BETWEEN 0 AND 100),
    status INTEGER NOT NULL,
    latitude NUMERIC(9,6) NOT NULL,
    longitude NUMERIC(9,6) NOT NULL,
    altitude NUMERIC(10,2) NOT NULL,
    CONSTRAINT pk_drone_telemetries PRIMARY KEY (drone_id, timestamp)
);
