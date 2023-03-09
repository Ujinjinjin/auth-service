build:
	docker build . -t ujinjinjin/auth-service:latest

push:
	make build
	docker push ujinjinjin/auth-service:latest

up:
	make build
	docker compose -f local.yml up -d
