# 🔐 JwtAspNet

Projeto simples desenvolvido como parte de estudos introdutórios sobre **autenticação com JWT (JSON Web Token)** utilizando **ASP.NET**.

> Este projeto foi feito acompanhando o curso do [Balta.io](https://balta.io), com foco didático na geração e uso de tokens JWT em aplicações .NET modernas.

---

## 📚 O que foi implementado?

- Estruturação básica da aplicação ASP.NET
- Criação do modelo `User` como `record`
- Geração de token JWT com:
  - Claims personalizadas (`Id`, `Name`, `Email`, `Image`)
  - Roles de usuário
- Classe de extensão para recuperar claims via `ClaimsPrincipal`
- Configuração via `appsettings.json`
- Serviços separados por responsabilidade (`TokenService`, `Configuration`, etc.)
