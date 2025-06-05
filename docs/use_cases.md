# Розроблення функціональних вимог до системи

## Модель прецедентів

### Загальна схема
![general-use-case-diagram.png](images_use_cases/general-use-case-diagram.drawio.png)

### Користувач
![user-use-case-diagram.png](images_use_cases/user-use-case-diagram.drawio.png)

### Адміністратор
![admin-use-case-diagram.png](images_use_cases/admin-use-case-diagram.drawio.png)

## Сценарії використання
| ID:                | ` CreateAccount ` |
| :------------------| :--------------|     
| Назва:             | Створення акаунту |
| Учасники:          | Користувач, система |
| Передумови:        | Користувач не має акаунту в системі |
| Результат:         |  <div style="width:500px">Створено новий акаунт</div> |
| Виключні ситуації: | - Обов’язкові поля не заповнені — ` NullReferenceException `<br>- Акаунт вже існує — ` UserAlreadyExistsException `<br>- Пароль не відповідає вимогам — ` NotStrongPasswordException ` |
| Основний сценарій: | 1. Користувач відкриває форму реєстрації<br>2. Вводить необхідні дані<br>3. Натискає "Зареєструватися"<br>4. Перевіряється коректність введених даних<br>5. Якщо всі перевірки пройдені, створюється акаунт |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/ZLBDIW9H5Dxx51TRjn8t6c4Bjn953s1wCs6QaPah6Sp2qSnD9CGmGX3X6zYWP9EZht3E6tNk6KOdA4ZG-tFFztC-JyLHTLjrRuoS2o-mmJwiqCC13Y64EOxTdA0FrvHvMnBmZ04i8DAbNEGBl6Va6eU2bYNwJD6djmSCSBf7Kls6i2jwVHGGmvAExpXYmXW3GSjSRtQ8L-8OQ4iGiH8jCM6s495M7gPqcH7KhbC0Jl892_-uC4iQ8yarpDsK_ut0H00X1WIVeA-TQR1Msl1JHA2OdZqsJG8XNIxe6nFZAB7CsqJEj9GKThjrhSI1R1GBnG9V7rqUw_vNHFk5JpZcTj7ZA8PfKALTwQ6eTGtZJ5v9MveDMUqrP4UrBJDJSE58-yImPRrvL-sr7UNyLbIprBcoBRDrMdUSMyjk_YoIPfCDyo7DP4ODXxfvykaBpZiauvz2_rdaFe1eV_L1tMzrjDcm_vwaVUGuoeo27XmlbTNH_bVFKLQddAjG7pJ2tm00" 
       width="700px" 
       alt="CreateAccount Diagram">
</div>

| ID:                | ` EditAccount ` |
| :------------------| :--------------|      
| Назва:             | Редагування інформації акаунту |
| Учасники:          | Користувач, система |
| Передумови:        | Користувач авторизований |
| Результат:         | <div style="width:500px">Оновлена інформація про акаунт</div> |
| Виключні ситуації: | - Некоректний формат даних — ` InvalidDataException ` |
| Основний сценарій: | 1. Користувач переходить у налаштування акаунту<br>2. Вносить зміни<br>3. Натискає "Зберегти"<br>4. Перевіряється коректність введених даних<br>5. Якщо все коректно, оновлюється інформація про акаунт |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/VLBDJi9W4BptARxWsHFX0iPmq8EFKQ5H4Ym4g_7G0pyY7emaXa1YeiOtg1LZKsXzXTatShxlWv9uiCtNR7TdPsQthLy6RY-ukcWx8PwHIn-936Ge8yI8P18wYfV1r4nOLNZ3b_HvniYnH4BmWvAHGeO8ApRTRzkPoMIg6AIy8oOpNIg8dWZ8PR2Xm3VMCcSgAG0lR1fgGwPzfafOuCEgurDNIXPg7Y7UhNSMruZ2FtOHorpwCfMPLYEEnbBaffIoAMDvO8t4Y9bSyj2CZ1N3o8PMpky4dkgrpiu3jUSrAkLAsQGFJW_rJ0bIhEHH9ffIRSORqVyT5HRL0hglJlnhjzrg7hc1UtpJyBf1g-ERikStZSXsX5UzACI6TcTVBqjkpGXhIyyaVlYQAqIxZTSSm_Flz-rqQqwTilmHVW40" 
       width="700px" 
       alt="EditAccount Diagram">
</div>

| ID:                | ` DeleteAccount ` |
| :------------------| :--------------|
| Назва:             | Видалення акаунту |
| Учасники:          | Користувач, система |
| Передумови:        | Користувач авторизований |
| Результат:         | Акаунт видалено |
| Виключні ситуації: | - Користувач не підтвердив видалення — ` CancelledOperationException ` |
| Основний сценарій: | 1. Користувач переходить у налаштування<br>2. Обирає "Видалити акаунт"<br>3. Підтверджує дію<br>4. Видаляється акаунт |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/VP51IiDW48NtESLGrwvADwr8GLnxXfZ-Q24c8KPmaKNQe7KXBOX4SA5uWrXI2Qtj6TxSoETV4dSc15w6xysRV_xXTUB6oSsLxwHunKupr3hHgUPOejHPwWWVomoix0lUiTACtnrsg50JVXJD1LkKsD3qqDXPsUgYzRtXatH6ubawU4ADoZhO0RLGhlcMcjCqxVobQO6AnDAcLlZId7wM2ftleI1CZCJZYyj43epNw_QwjdnqVYmsPOsDpdN6jeNen0wSC-UU7LxwBNee9sxW6TytexF8n6uo3eFJMyz4ly9I9XZPBCV-fVZOhmehVADCctdRS-c2SrAqPneqnd_s74O3PyWWNiWF" 
       width="700px" 
       alt="DeleteAccount Diagram">
</div>

| ID:                |<div style="width:500px">` CreateProject `</div>   |
| :------------------| :--------------|      
| Назва:             | Створення проєкту |
| Учасники:          | Користувач, система |
| Передумови:        | Користувач авторизований |
| Результат:         | Створено новий проєкт |
| Виключні ситуації: | - Некоректно введені дані — ` InvalidDataException ` |
| Основний сценарій: | 1. Користувач натискає "Створити проєкт"<br>2. Заповнює необхідні поля<br>3. Підтверджує дію<br>4. Перевіряється коректність введених даних<br>5. Якщо все коректно, створюється проєкт |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/VL7FIW9n4BxlKmnsxYHUDC937NgCJPSIR1Nx5HtsO8fv2OKGXI32DzWM3T7KL_ZcZVgShHzqIL36-VvyC_Ehthgmu-vkca62L-oqYvK-Qa_xo93gC0c47-DKh2mBtWZq3ZIiMKsaW3d_PpzY8e8zonsMM6klu7KpfDYpdM6h8-gm9ME73nte50isfsBuHiTUytw0p7sfNP8-jKybMrCTvIJxIJ3FvwRZ5zB4oqssH4P-LySwuMRFv8q5QvlNHZn4iqb86CGeBFZTqd4WBDEypEFYbekaqxYwTd8KrKh5Kj7Q9vUdWXUiQBlXSaFRXXTQsIbJVMB2hEofnt8HtuVDHlqiTE7vGorgkqOhDZYAwnRokuA_BMtz-7ykN0cC--_xjTgLe4fhFlGt" 
       width="700px" 
       alt="CreateProject Diagram">
</div>

| ID:                | <div style="width:500px">` EditProject `</div> |
| :------------------| :--------------|      
| Назва:             | Редагування проєкту |
| Учасники:          | Користувач, система |
| Передумови:        | Користувач має дозвіл на редагування |
| Результат:         | Оновлена інформація про проєкт |
| Виключні ситуації: | - Доступ заборонено — ` AccessDeniedException ` |
| Основний сценарій: | 1. Користувач відкриває проєкт<br>2. Вносить зміни<br>3. Натискає "Зберегти"<br>4. Перевіряється коректність введених даних<br>5. Якщо все коректно, зберігаються зміни |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/VL5DIiDG4Dxd58-wTbMwQKKgw44qVMX0az94S955awBTI0jIKX14l45C3OROr2jySoFdJPAA6nC8apVVV3zlXdvmFWbkRwwj4C_OqHG5HHJJ31bIceUMuaSm0odx2a-Ku0EbWGfefV3DFplaV1Z_mb0nNuI2sHuLFh7bkGh57l32ix6HGoai7QpnZfofScnCfrD3vHFYhNR6pItIi2LvRGOoIcXAIrePDSOj5Kg98wPGSJkgZMJyvXmWDsReNd6PrcKjvtg1LXFdyYfG1zhkTNjTEJwwE3QP2gRzeWND3QLguitO_mChhFjxwA4wiMtj-wVQTVJexCxMuy3nNEbhToGgJOOsDYNOCD6YJV3dpWJxxugyyS0QCZNlyWS0" 
       width="700px" 
       alt="EditProject Diagram">
</div>

| ID:                | <div style="width:500px">` DeleteProject `</div> |
| :------------------| :--------------|      
| Назва:             | Видалення проєкту |
| Учасники:          | Користувач, система |
| Передумови:        | Користувач має права на видалення |
| Результат:         | Проєкт видалено |
| Виключні ситуації: | - Доступ заборонено — ` AccessDeniedException ` |
| Основний сценарій: | 1. Користувач відкриває проєкт<br>2. Натискає "Видалити"<br>3. Підтверджує дію<br>4. Видаляється проєкт |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/VP11IiDW48NtESLGrwvADur81Js8fZyQqAGql-0Y2qt1RgI5KY888juWb4H2glKARsxa_5FyLs8M8VFcotlC6sNsV6flRww372_OyJrQVk22PzYWudaUa3pAXFev9AouH8tEeGgj2TyoxD28M7ZiLLQ5SqEdK0yhjAXHOOlMRNeUVNEE8ctGY56D3vx93oALl0X9gIIrXgRnvPMb0nCD-eE-oaSNnwI-7RQyu3c-k2I9RDq94lie5iz3ZnxIIHIPB3irIMp6PtUHcTWuJNHlal4-XGATSxplkq23JrIvF__t2bxoMcAUX5d-KO6-_YqrdOJ1I6Ab_Hy0" 
       width="700px" 
       alt="DeleteProject Diagram">
</div>

| ID:                | <div style="width:500px">` AddMembers `</div> |
| :------------------| :--------------|
| Назва:             | Додавання учасників у проєкт |
| Учасники:          | Адміністратор, система |
| Передумови:        | Користувач має права на додавання |
| Результат:         | Додані нові учасники |
| Виключні ситуації: | - Доступ заборонено — ` AccessDeniedException `<br>- Користувач уже в команді — ` UserAlreadyInTeamException ` |
| Основний сценарій: | 1. Адміністратор відкриває налаштування команди<br>2. Додає нових учасників, вводячи їхню пошту або ID<br>3. Перевіряється коректність введених даних<br>4. Якщо все коректно, додаються учасники |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/ZLB1Ql9W4BpdAHR-wz-JU36bADY3z_O1RFne1OsIfD123b6nxK6q5D5ZwHlO4E53JVeAks_K-H8CjQSAmcPsTcTcaxeVjBtWlj-pGdxbX0-oubHMCfAnHBoHCMSIXHRXbpFjlAmHlu6Oy0uapJ68I-AKDxn7-OBPYG61fB8Wtd761_E82LrkM09DZfCP-5gc91Dv1ZO2f7a7ZVW_eHKRhYpGqoHhcMBldFYBiqACiFoJCserRI8h5mZvWxM9mLkZ7HvLttah4R0O8IDiN69-1bvXqxGWEovlCClL0IRufxb5OxeeYoZk853aTM_l0lgdd6gbMidXyviBNCcauBtCuHmh2S6qCOo8Jr1Orqhg6JKSH_b-KxbTrRbySDGmw0xS7_rhNtcDdgVQdSUMUwNQ_LEISZk5bT_tdPS9Ju_BsYvEzOStFnZQLXqA-52-0G00" 
       width="700px" 
       alt="AddMembers Diagram">
</div>

| ID:                | <div style="width:500px">` EditMemberPermissions `</div> |
| :------------------| :--------------|
| Назва:             | Редагування дозволів учасників |
| Учасники:          | Адміністратор, система |
| Передумови:        | Користувач має права адміністратора |
| Результат:         | Оновлені дозволи учасників |
| Виключні ситуації: | - Доступ заборонено — ` AccessDeniedException ` |
| Основний сценарій: | 1. Адміністратор відкриває список учасників<br>2. Змінює права доступу для конкретного користувача<br>3. Перевіряється коректність введених даних<br>4. Якщо все коректно, зберігаються зміни |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/XLB1Ji904BttAoRnx8bm0MCmqG_Hib4IBOJMn4CFfOrw8SKO0aVZ7zHIObDf-OMPF_BjBfQZ93IxCs_Uc_VQWHzSJuF7Xtidv3SkU2ShhcKbCuabuanYRYGA7SBF8Flcs2D-1x3W2g2ISm2N93FUSubdmnL98g-SuLAZNm6RjvFhWqYA6Tvh5Kr0O6kCR89Yegy_iY2kG5SRdIsMgN7RS6FAMlemW7ajrtUCHiYVjiDRtd4M_Wb_W08qdCDV90jPOdOEd5KnhKhYrlwSm9kZME0F6_9CE6RsQDsGDmuKJKUtTm6TABVRwNPC_Upc70bfvp2HOZLmwdnAisqcBv1OzrheALsuhlBzI-MDrF3goLMJO3JsJ5zvGwj2T0pmIpj1Y1jmfKSNtpPPBjiW_dsbuqdV6K03Ny0l" 
       width="700px" 
       alt="EditMemberPermissions Diagram">
</div>

| ID:                | <div style="width:500px">` RemoveMembers `</div> |
| :------------------| :--------------|
| Назва:             | Видалення учасників із проєкту |
| Учасники:          | Адміністратор, система |
| Передумови:        | Користувач має права на видалення |
| Результат:         | Учасника видалено з проєкту |
| Виключні ситуації: | - Доступ заборонено — ` AccessDeniedException ` |
| Основний сценарій: | 1. Адміністратор відкриває список учасників<br>2. Обирає учасників для видалення<br>3. Підтверджує дію<br>4. Видаляються учасники |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/XP6_IiDG5CRtFCK1PwVIfH6fe0-YwKK3cfGcWaE6D0LTf14fTLDyWrWQ2MbJN-4xR-IN2ysWGpE4UtD_v_kJEupYoqbyVtVh97Z16bjTej6bJZNJ58Lcs6cQECB7agvT3WIl1DUe2LLO4Lo8Jl63YkyTQj6PFg7Wfk5vJNRLJRxZYrXgP_vZGjMDvaBHYii26vGyRJJl13vQQyr8b9gI-QRAWdECFNU9M4w2C3OoyQzlOZaoNh_Nxzdl9rUd3D-wqMPETxPjerSiF6EKHwgy3JhqMCuypqJHkGbyCxfuyCmuziF0dfjWP5qSkqlmsRPdhX9R54dte_OzDATVfizayZ_5KRbxaOEN48vTPqXhtjal" 
       width="700px" 
       alt="RemoveMembers Diagram">
</div>

| ID:                | <div style="width:500px">` CreateTask `</div> |
| :------------------| :--------------|
| Назва:             | Створення завдання |
| Учасники:          | Користувач, система |
| Передумови:        | Користувач має права на створення завдань у проєкті |
| Результат:         | Створено нове завдання |
| Виключні ситуації: | - Некоректно введені дані — ` InvalidDataException `<br>- Доступ заборонено — ` AccessDeniedException ` |
| Основний сценарій: | 1. Користувач відкриває проєкт<br>2. Натискає "Створити завдання"<br>3. Вводить назву, опис, дедлайн, виконавців<br>4. Підтверджує дію<br>5. Перевіряється коректність введених даних<br>6. Якщо все коректно, створюється завдання |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/VPBFIiD04CRlUOgXNkkfzDA8LAW77oEcYmPgMjee7d9eMhGNQK5A1K6aRn2MrZ-fQLzXvetyTeDH4ImqPEVxpSptiMaE8gyVNLvqd9WVUIj3VfD4HZ9cpQbCOeVmiunhNnl4zxBW5MS6jT2SU8V3bjSeZahi2TB8JEFCGXLUugoB7KOXVkKKXHMUEUSogtolC1m4S797K5EmMiPLGdc7Sb8bo6lyDz3UESTPmqy67JJOMxZKvS1duzckNyiGNIyoXYMK5Z9roI7BnRmiqcFm1wTnsMoQKDEWXpAJkN45RaPcdvKGd7F8IM5OcqNMO8w9DsGpsjV2KTYD5FM3i_E8zfHVhzLhjdnmUeZiDiP6fZ8n8qaIz9aBIKqcUMYKw3wTX5TU9sYtlCWxllPLBmgwuG_voFVLOD1IOQ3QltKLjWiJz1Mol1miBWF-kIBNiVo_tqgtvpfDBC17zGa0" 
       width="700px" 
       alt="CreateTask Diagram">
</div>

| ID:                | <div style="width:500px">` EditTask `</div> |
| :------------------| :--------------|
| Назва:             | Редагування завдання |
| Учасники:          | Користувач, система |
| Передумови:        | Користувач має дозвіл на редагування завдання |
| Результат:         | Оновлене завдання |
| Виключні ситуації: | - Доступ заборонено — ` AccessDeniedException ` |
| Основний сценарій: | 1. Користувач відкриває завдання<br>2. Вносить зміни (назва, опис, дедлайн, виконавці)<br>3. Натискає "Зберегти"<br>4. Перевіряється коректність введених даних<br>5. Якщо все коректно, зберігаються зміни |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/VLB1Jl906BptAJRybzz4JuGB68E9FeYMZP9e8L0J3pr0YN8na1XI4XDZV8DQQ4IWy0hplP6pMoWtsxJPtPbllfclhNVzgux_S7_d17Z3HdfOI5z26I11BCF0KRmifsQNLOLNYJ37qb0jQQAmvMQ3b8VXWOQCUdtgXVAYy8qrwp8ir7--O-vPUwnOjZKjkPeZvRCYzeEC-uJwI-A6dSYpH4U5zZlRXgQC16EWX2c-aD95Yfb1IgHQSe3FF16HDU9Wh_2nOoSIIK_6CZ4koHihqvEG3OECS3yFaF1EhKc6a2VZDywNkIslvMlLQTxS-kgVTYlbIjaUdrwVSHOsoaf6CZIIQZUM0MAJIwRLWdgYpbrNTxiNsclgnkMZgzj-i-LPN7kDl8lQfTYdbWWpIesA38TfrnpB_VFZjjerfqvn_WM_" 
       width="700px" 
       alt="EditTask Diagram">
</div>

| ID:                | <div style="width:500px">` DeleteTask `</div> |
| :------------------| :--------------|
| Назва:             | Видалення завдання |
| Учасники:          | Користувач, система |
| Передумови:        | Користувач має дозвіл на видалення завдання |
| Результат:         | Завдання видалено |
| Виключні ситуації: | - Доступ заборонено — ` AccessDeniedException ` |
| Основний сценарій: | 1. Користувач відкриває завдання<br>2. Натискає "Видалити"<br>3. Підтверджує дію<br>4. Видаляється завдання |
<div style="text-align: center; margin: 5px 0px 20px;">
  <img src="https://www.plantuml.com/plantuml/png/VP71IiDG54Jt_OfBNRigtJGY5VH3D7reG9FIFC555jg2tKW3fKGGHFo3HqWrfCPlcFj7tdUBMObPXPd337VUEBNdCtjxSztBy89llaVD3ppd1KeuNcOzaa-PG7z7X3KNgD1uLA4DuHCEfOWEBLhEE_HLxBbFHADW7slKokrGUwVVeMy-LQGIMqckyC4BdrnnmQk0b8eJQsWMNLvPEZ3XS30Sg7nqSKoQss37ArwYvOAaijOp73zAnFEeGm_f90nDcfwQE3AJixlGJ6sKnEgRUB9laK8LChpl1y4MNt1Pjy7l6PppHdgUXCd_s47vVvTDfa5lBBto13y0" 
       width="700px" 
       alt="DeleteTask Diagram">
</div>
