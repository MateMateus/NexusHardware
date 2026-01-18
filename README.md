📖 Guia de Bordo — Projeto NexusHardware
🎬 Contexto
O NexusHardware é um sistema de gerenciamento de inventário e montagem de setups para uma loja de informática especializada (High-End & Custom Builds). Diferente de um catálogo estático (filmes), aqui lidaremos com estoque, valores monetários e marcas, o que traz uma complexidade extra interessante para o seu portfólio.

🏛 Arquitetura em Camadas (Mantendo o Padrão Saphira)
A solução continua dividida em 5 projetos, mas com responsabilidades adaptadas:

NexusHardware.Domain

Entidades: Componente, Categoria (CPU, GPU, RAM), Fabricante (Asus, Intel, Atermit), Usuario.

Regras: Um componente não pode ter preço negativo; o estoque não pode ser negativo.

NexusHardware.Application

Interfaces e Serviços.

Lógica: Dar baixa no estoque quando um componente é reservado; calcular o valor total de itens de uma marca específica.

NexusHardware.Infrastructure

NexusDbContext, Mapeamento (EF Core), Migrations.

NexusHardware.Api

Endpoints para o front-end consumir (JSON).

Autenticação via Token JWT.

NexusHardware.Web

Interface visual (MVC/Razor ou HTML+JS puro consumindo a API).

Dashboard administrativo com gráficos financeiros.

👥 Perfis de Usuário
Admin (Dono): Acesso total. Pode cadastrar fabricantes e ver o dashboard financeiro (Custo total do estoque).

Estoquista (Gerente): Pode cadastrar componentes e atualizar quantidades. Não pode excluir fabricantes nem ver o lucro total.

Cliente (Visualizador): Pode ver o catálogo de peças ("Vitrine") e filtrar por compatibilidade, mas não vê botões de editar/excluir.

📊 Funcionalidades (Diferenciais do Saphira)
Catálogo: Cards de componentes exibindo Preço, Estoque e Marca.

Indicadores Visuais: Se o estoque for < 5, o card fica com borda vermelha (Alerta de Estoque Baixo).

Dashboard (Admin):

Gráfico Pizza (Chart.js): Distribuição de estoque por Categoria (Ex: 40% GPU, 20% CPU).

Gráfico Barra: Valor total investido por Fabricante.

Card de KPI: Valor total do inventário em R$.

🐙 O Plano de Integração com Git (Learning Path)
Para "melhorar o seu git" de verdade, não vamos apenas dar git add .. Vamos simular um fluxo de trabalho profissional chamado Git Flow Simplificado.

Regras de Ouro para este Projeto:
Nunca commite direto na main: A main é a versão "sagrada" que funciona.

Commits Semânticos: Escreva mensagens que expliquem O QUE e ONDE mudou.

Ruim: "alterações", "arrumando bug"

Bom: feat: adiciona entidade Componente, fix: corrige validação de preço, style: ajusta cor do navbar

Seu Fluxo de Trabalho por Fase
Para cada Fase do desenvolvimento (que você listou no Saphira), você fará o seguinte ciclo no terminal:

1. Preparar o terreno (Início do Projeto)

Bash
git init
git checkout -b main  # Cria a branch principal
git checkout -b develop # Cria a branch de desenvolvimento (onde a mágica acontece)
2. Trabalhando em uma Fase (Ex: Fase 1 - Domínio) Sempre que começar uma fase nova, crie uma Feature Branch saindo da develop.

Bash
# Estou na develop
git checkout -b feature/fase1-dominio

# ... (Você coda as classes: Componente.cs, Categoria.cs) ...

git add .
git commit -m "feat(domain): cria entidades iniciais e validacoes"

# ... (Terminou a fase 1 toda) ...
3. Integrando o Código (Merge) Quando terminar a fase, você joga o código da sua feature de volta para a develop.

Bash
git checkout develop
git merge feature/fase1-dominio --no-ff
# O --no-ff cria um "nó" no histórico, facilitando ver onde a feature começou e terminou.

git branch -d feature/fase1-dominio # Deleta a branch da feature, já que já foi integrada.
4. Checkpoint (Release) Quando o projeto estiver estável (ex: rodando a Fase 3 sem erros), você atualiza a main.

Bash
git checkout main
git merge develop
git tag -a v1.0 -m "Versão 1.0 - Backend Funcional" # Cria uma etiqueta de versão
🗓 Plano por Fases (Adaptado para NexusHardware)
Aqui está o seu roteiro prático. Para cada fase, lembre-se de criar uma branch feature/faseX-....

Fase 0 — Setup & Git Init:

Criar a Solution .sln.

Criar os 5 projetos (Class Libs e Web Apps).

Git Task: Configurar o .gitignore para ignorar as pastas bin e obj (essencial para projetos .NET).

Fase 1 — O Coração (Domain & Infra):

Entidades: Componente (Propriedades: Nome, Preco, QtdEstoque, ImageUrl), Fabricante.

EF Core: Mapear 1 Fabricante tem N Componentes.

Fase 2 — Regras (Application):

Criar ComponenteService.

Regra de Negócio: Impedir cadastro se o Preço < 0.

Fase 3 — API (Back-end):

Controllers: ComponentesController, AuthController.

Swagger: Testar o CRUD sem front-end.

Fase 4 — A Vitrine (Web):

Consumir a API com fetch.

Renderizar os cards das peças (GPUs, CPUs).

Desafio JS: Fazer o filtro funcionar sem recarregar a página.

Fase 5 — Segurança (Identity):

Login/Logout.

Esconder o botão "Editar" se o usuário não for Admin/Gerente.

Fase 6 — O Painel do Chefe (Dashboard):

Implementar Chart.js.

Query LINQ: Agrupar componentes por Categoria e somar o valor total.
