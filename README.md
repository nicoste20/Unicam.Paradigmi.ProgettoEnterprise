# Web API per la Gestione dei Corsi di Formazione

Questo progetto consiste nella realizzazione di una Web API per la gestione dei corsi di formazione. L'applicazione offre funzionalità per la gestione degli utenti, dei corsi, delle lezioni, delle presenze e delle operazioni di autenticazione.

## Tecnologie Utilizzate
- Linguaggio di programmazione: C#
- Framework: ASP.NET Core
- Database: SQL

## Requisiti del Database
Il database utilizzato è di tipo relazionale e prende il nome di `Paradigmi_Progetto`. Le credenziali per l'accesso al database sono le seguenti:
- Username: paradigmi
- Password: paradigmi
Per creare il database e popolarlo con dati di esempio, è possibile utilizzare il dump fornito nel progetto `Unicam.Paradigmi.Models`, all'interno della cartella `Database`.

## Avvio del Progetto
Per avviare il progetto, seguire i seguenti passaggi:
1. Aprire il progetto `Unicam.Paradigmi.Web`.
2. Avviare l'applicazione.

## API Disponibili

Le seguenti API sono disponibili per l'utilizzo:

- **Creazione di un utente (anonima senza autenticazione) e con invio di email di benvenuto al nuovo utente**
- **Autenticazione**
- **Creazione di un Corso**
- **Eliminazione di un corso**
- **Aggiunta di lezioni a un corso**
- **Aggiunta di una presenza ad una lezione**
- **Rimozione di una presenza da una lezione**
- **Ricerca delle presenze di un corso**
  - **Filtri disponibili**:
    - Nome del corso
    - Cognome dell'alunno
    - Docente
    - Data della lezione (senza orario)
