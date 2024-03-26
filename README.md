# 🌊 shoreline

A simple chatbot for Pineapple Cove.

![License](https://img.shields.io/github/license/tacosontitan/shoreline?logo=github&style=for-the-badge)
![.NET Workflow](https://img.shields.io/github/actions/workflow/status/tacosontitan/shoreline/build.yml?label=Build%20and%20Test&logo=dotnet&style=for-the-badge)

## 💁‍♀️ Getting Started

Get started by reviewing the answers to the following questions:

- [How do I navigate the codebase with confidence?](http://shoreline.tacosontitan.com)
- [How do I report security concerns?](./SECURITY.md)
- [How should I behave here?](./CODE_OF_CONDUCT.md)
- [How can I help?](./CONTRIBUTING.md)
- [What's the latest?](./resources/RELEASE_NOTES.md)
- [Where are we going next?](./resources/ROADMAP.md)

### 📦 How do I configure my environment?

Once you've cloned the repository locally, you'll need to create a `.env` file for environment variables.
You can use the `.env.example` file as a template and populate it with the necessary values.

### 🐋 How do I run this project?

This project is built with .NET and uses Docker for development.
You'll need to have Docker installed on your machine to run the project.
Finally, you can run the following in a terminal from the repo root:

```bash
docker compose up -d --build
```