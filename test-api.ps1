# test-api.ps1
# ✅ 1. Créer un étudiant
$registerBody = @{
  nom = "Afi"
  email = "afi.new@example.com"    
  numero = "999888768"               
  motDePasse = "MotSecret123!"
  photoCarte = "https://exemple.com/photo.jpg"
} | ConvertTo-Json -Depth 5


Write-Host "`n👉 Envoi de la requête d'inscription..."
$registerResponse = Invoke-RestMethod -Uri "http://localhost:5290/api/Student/register" `
  -Method POST `
  -Body $registerBody `
  -ContentType "application/json"

$registerResponse | ConvertTo-Json -Depth 5

# ✅ 2. Connexion
$loginBody = @{
  numero = "999888777"
  motDePasse = "MotSecret123!"
} | ConvertTo-Json

Write-Host "`n👉 Connexion..."
$loginResponse = Invoke-RestMethod -Uri "http://localhost:5290/api/Student/login" `
  -Method POST `
  -Body $loginBody `
  -ContentType "application/json"

$token = $loginResponse.token
Write-Host "`n✅ Token reçu : $token"

# ✅ 3. Tester une route protégée avec le token
Write-Host "`n👉 Test d'une route protégée (liste des réservations)..."

Invoke-RestMethod -Uri "http://localhost:5290/api/Reservation/student/2" `
  -Headers @{ Authorization = "Bearer $token" } `
  -Method GET
