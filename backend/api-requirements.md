# Tasks Page API requirements

- list of upcoming tasks
- tasks for a given day
- CRUD operations for a given task
Authorized - all tasks belong to the specified user

Task: {
    name: string,
    notes: [{id: int, name: string},...],
    date: "YYYY-MM-DD-HH:MM:SS"
    duration: int // in minutes
}

## Routes

GET /tasks?upcomingDays=7 - List of tasks in the next 7 days
GET /tasks?date=2026-02-14 - List of tasks on specified date
GET /tasks - List of all tasks
GET /tasks/{id} - Get task by id
POST tasks - Create task
PATCH tasks/{id} - Update task by id
DELETE /tasks/{id} - Delete task by id

# Finance Page Requirements

- Total Expenses and Income by month
- Expected expenses over date range
- CRUD for expenses/income
- Upcoming Expenses
- Expenses by month split by category

Transaction : {
    name: string,
    value: float,
    estimateValue: float | null,
    type: "expense" | "exact",
    date: "YYYY-MM-DD-HH:MM:SS",
}

RecurringTransaction : {
    name: string,
    value: float,
    estimateValue: float | null,
    type: "expense" | "exact",
    date: "YYYY-MM-DD-HH:MM:SS"
    frequency: "weekly" | "fortnightly" | "monthly"
}

## Routes

GET /transactions/total?month=2026-02 - get total income & spending in feb 2026
    Simply sums the total current transactions for the given month
GET /transcations/expected?month=2026-02 - get expected income & spending in feb 2026
    This is calculated using estimate values of estimate transactions + upcoming transactions

GET /transactions?splitByCategory=true
    return JSON obj where each key is a category to a list of transactions e.g.
    {"food":[...], "rent":[...], ...}

GET /transactions?month=2026-02 - List of transactions for a given month

GET /transactions - List of all transactions
GET /transactions/{id}
PATCH /transactions/{id}
DELETE /transactions/{id}
POST /transactions

--- Note: Backgroudn job run to create transaction entry for each recurring transaction
GET /recurring-transactions/upcoming 
GET /recurring-transactions
GET /recurring-transactions/{id}
PATCH /recurring-transactions/{id}
DELETE /recurring-transactions/{id}
POST /recurring-transactions


# Notes Page Requirements

- All groups and note names to a specified depth
- Note Name and content
- CRUD for notes

Note: {
    title: string,
    content: string,
    position: int,
    parentId: int | null
}

Group: {
    title: string,
    notes: [{id:int title: string},...],
    children: [{id:int title: string},...],
    parentId: int | null,
    position: int | null
}

## Routes

GET /root - Gets all top level groups and notes
    returns {notes: {id,name}, groups: {id,name}}

GET /notes
GET /notes?query=work - Returns notes with similar name
GET /notes/{id}
PATCH /notes/{id}
DELETE /notes/{id}
POST /notes

GET /groups
GET /groups/{id}
PATCH /groups/{id}
DELETE /groups/{id}
POST /groups

