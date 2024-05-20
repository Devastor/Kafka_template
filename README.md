
# Messaging App Case Study

## Описание кейса

Этот проект представляет собой простое приложение для обмена сообщениями, где пользователи могут отправлять и получать сообщения в режиме реального времени. 
Приложение состоит из нескольких микросервисов: 
backend на C# .Net Core, 
фронтенд на React.js, 
брокер сообщений Kafka, 
база данных PostgreSQL,
контейнеры Docker (управляемые в Kubernetes)

## Структура проекта

### 1. PostgreSQL Dockerfile
**Файл:** Dockerfile
Описание: Этот файл используется для создания Docker-контейнера для базы данных PostgreSQL. Он настраивает базу данных с именем `messages` и устанавливает пользователя и пароль.

### 2. Kafka Docker Compose
**Файл:** docker-compose.yml
Описание: Этот файл используется для настройки и запуска Kafka и Zookeeper с использованием Docker Compose. Kafka используется для обработки и передачи сообщений между микросервисами.

### 3. Backend на C# .Net Core
**Файлы:**
- **Model.cs**: Содержит модель данных `Message` и контекст базы данных `MessagesContext`, настроенный для использования PostgreSQL.
- **KafkaProducer.cs**: Содержит класс `KafkaProducer`, который используется для отправки сообщений в Kafka.
- **KafkaConsumer.cs**: Содержит класс `KafkaConsumer`, который используется для получения сообщений из Kafka.
- **MessagesController.cs**: Содержит контроллер ASP.NET Core, который обрабатывает HTTP-запросы для отправки сообщений и взаимодействует с базой данных и Kafka.

### 4. Frontend на React.js и TypeScript
**Файлы:**
- **SendMessage.tsx**: Компонент для отправки сообщений. Содержит форму для ввода сообщения и кнопку для его отправки.
- **ReceiveMessages.tsx**: Компонент для получения сообщений. Отображает список полученных сообщений.
- **App.tsx**: Основной компонент приложения, объединяющий компоненты отправки и получения сообщений.

### 5. Dockerfile для Backend
**Файл:** BackendDockerfile
Описание: Этот файл используется для создания Docker-образа для backend-приложения на C# .Net Core.

### 6. Dockerfile для Frontend
**Файл:** FrontendDockerfile
Описание: Этот файл используется для создания Docker-образа для фронтенд-приложения на React.js.

### 7. Kubernetes манифесты
**Файлы:**
- **postgres-service.yml**: Манифест для создания сервиса PostgreSQL в Kubernetes.
- **postgres-deployment.yml**: Манифест для развертывания PostgreSQL в Kubernetes.
- **kafka-service.yml**: Манифест для создания сервиса Kafka в Kubernetes.
- **kafka-deployment.yml**: Манифест для развертывания Kafka в Kubernetes.
- **backend-service.yml**: Манифест для создания сервиса backend-приложения в Kubernetes.
- **backend-deployment.yml**: Манифест для развертывания backend-приложения в Kubernetes.
- **frontend-service.yml**: Манифест для создания сервиса фронтенд-приложения в Kubernetes.
- **frontend-deployment.yml**: Манифест для развертывания фронтенд-приложения в Kubernetes.

## Запуск проекта

### 1. Запуск базы данных PostgreSQL
Используйте Docker для создания и запуска контейнера PostgreSQL:
```sh
docker build -t postgres-db .
docker run -d -p 5432:5432 --name postgres-db postgres-db
```

### 2. Запуск Kafka
Используйте Docker Compose для настройки и запуска Kafka и Zookeeper:
```sh
docker-compose up -d
```

### 3. Запуск Backend
Создайте Docker-образ и запустите контейнер для backend-приложения:
```sh
docker build -t backend -f BackendDockerfile .
docker run -d -p 5000:80 --name backend backend
```

### 4. Запуск Frontend
Создайте Docker-образ и запустите контейнер для фронтенд-приложения:
```sh
docker build -t frontend -f FrontendDockerfile .
docker run -d -p 3000:80 --name frontend frontend
```

### 5. Развертывание в Kubernetes
Примените манифесты Kubernetes для развертывания всех компонентов:
```sh
kubectl apply -f postgres-service.yml
kubectl apply -f postgres-deployment.yml
kubectl apply -f kafka-service.yml
kubectl apply -f kafka-deployment.yml
kubectl apply -f backend-service.yml
kubectl apply -f backend-deployment.yml
kubectl apply -f frontend-service.yml
kubectl apply -f frontend-deployment.yml
```

Теперь ваше приложение должно быть доступно для использования. Удачи!
