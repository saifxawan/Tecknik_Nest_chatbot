AI-Powered Chatbot Web Application This repository contains the code for an AI-Powered Chatbot Web Application, developed as an internship project. The application features a .NET frontend, a Python backend for AI processing and file handling, and uses MongoDB for persistent chat history storage.

🚀 Project Overview This project aims to provide an intelligent, interactive chatbot solution capable of engaging in conversational dialogue, processing uploaded documents (PDFs and images), and maintaining a persistent chat history. It showcases a modern, decoupled architecture designed for scalability and maintainability.

✨ Features Interactive Chat Interface: A user-friendly web interface for real-time text-based conversations.

AI-Powered Responses: Integrates a pre-trained large language model (DialoGPT) to generate intelligent and contextually relevant replies.

Document Text Extraction: Supports uploading PDF and image (PNG, JPG, JPEG) files, from which the chatbot can extract and present the contained text.

Persistent Chat History: Automatically saves all chat messages, uploaded file details, and chatbot replies into a MongoDB database.

Chat History Retrieval: Provides an endpoint to easily fetch and display the complete history of interactions.

Scalable Architecture: Designed with decoupled components to allow for independent scaling of frontend and backend services.

Secure File Handling: Implements secure practices for managing uploaded files.

🛠️ Technologies Used Frontend (.NET Web Application) Framework: ASP.NET Core Razor Pages

Language: C#

Libraries: HttpClient for API communication, Microsoft.AspNetCore.Mvc for web functionalities.

Database Driver: MongoDB.Driver for interacting with MongoDB.

Backend (Python Flask API) Language: Python 3.x

Framework: Flask

AI Model: DialoGPT (microsoft/DialoGPT-medium) via transformers library.

PDF Processing: PyPDF2 for text extraction from PDF files.

Image Processing (OCR): Pillow (PIL) and pytesseract for Optical Character Recognition (OCR) on image files.

File Handling: werkzeug.utils.secure_filename for secure file uploads.

Database Type: MongoDB (NoSQL Document Database)

Purpose: Stores ChatHistory logs, including messages, file details, and chatbot replies.

🏗️ Architecture The application follows a decoupled architecture:

Frontend (.NET): Serves the web interface, handles user input and file uploads, and communicates with the Python backend via HTTP API calls.

Backend (Python): A Flask API receives requests from the frontend, processes messages, integrates with the AI model, extracts text from uploaded files, and interacts with the MongoDB database to save and retrieve chat history.

MongoDB: The central data store for all chat interactions.

graph TD A[User Interface - .NET Frontend] --> B(API Calls - HTTP/HTTPS); B --> C{Python Backend - Flask API}; C -- Text/File Upload --> C_1[AI Model (DialoGPT) & File Processors]; C_1 --> C; C --> D[MongoDB Database]; D --> C; C --> B;

⚙️ Setup and Installation Follow these steps to get the project up and running on your local machine.

Prerequisites .NET SDK (version 9.0 or later)

Python 3.x

MongoDB Community Server (or access to a MongoDB Atlas cluster)

Tesseract OCR (for image text extraction in Python backend) - Download Tesseract

Clone the Repository git clone <repository_url> cd <repository_directory>

Set up MongoDB Ensure your MongoDB instance is running. Update the connection string in the .NET project's appsettings.json (or appsettings.Development.json) file:

{ "ConnectionStrings": { "MongoDb": "mongodb://localhost:27017" // Or your MongoDB Atlas connection string }, // ... other settings }

Set up Python Backend Navigate to the PythonBackend directory (or wherever your chatbot.py is located):
cd path/to/your/PythonBackend

Create a virtual environment and install dependencies:

python -m venv venv source venv/bin/activate # On Windows: venv\Scripts\activate pip install Flask PyPDF2 Pillow pytesseract transformers torch

Important for Windows users: If you are on Windows, you might need to set the pytesseract.pytesseract.tesseract_cmd path in chatbot.py to your Tesseract installation directory:

pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe" # Adjust this path

Run the Flask application:

flask run --port 5000

The backend will run on http://localhost:5000.

Set up .NET Frontend Navigate to the ChatbotWebApp directory (or wherever your .NET project files are located):
cd path/to/your/ChatbotWebApp

Restore .NET dependencies:

dotnet restore

Run the .NET application:

dotnet run

The frontend will typically run on http://localhost:5001 (or another port specified by .NET).

🚀 Usage Ensure both the Python backend and .NET frontend applications are running.

Open your web browser and navigate to the .NET application's URL (e.g., http://localhost:5001).

You can now type messages into the chat interface.

Use the file upload functionality to send PDF or image files to the chatbot for text extraction.

The chat history will be automatically saved and can be retrieved via the /api/Chat/history endpoint (though the frontend might not yet have a dedicated UI for this).

📂 Project Structure (High-Level) . ├── ChatbotWebApp/ # .NET Frontend Project │ ├── Controllers/ │ │ └── ChatController.cs # Handles API calls to Python backend and MongoDB persistence │ ├── Models/ │ │ └── ChatHistory.cs # MongoDB model for chat logs │ ├── Services/ │ │ └── MongoService.cs # MongoDB interaction logic │ ├── Pages/ # Razor Pages for UI (e.g., Index.cshtml) │ ├── appsettings.json │ └── ... └── PythonBackend/ # Python Flask Backend Project └── chatbot.py # Flask app, AI model, file processing └── uploads/ # Directory for uploaded files (created automatically) └── venv/ # Python virtual environment

🤝 Contributing This is an individual internship project, but feedback and suggestions are welcome!
