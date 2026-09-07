# Sprint 0 - Game Design Document : Tower Defense 

Naam: Niklas Nikolaidis 

Klas: SD2A

Datum: 7-9-2026

# 1. Titel en elevator pitch 

Titel: Tour de défense 
>(Tower defense maar je bent french)

Elevator pitch, maximaal twee zinnen: Beschrijf kort wat jouw game is en waarom het leuk is om te spelen. 

Het is een normale Tower Defense maar je bent een franse generaal die de bad guys verslaan moet, je bouwt towers, defense en overleeft de battles

# 2. Wat maakt jouw tower defense uniek 

Beschrijf in één of twee zinnen wat jouw game onderscheidt van een standaard tower defense. Denk aan iets dat de speler op een nieuwe manier laat nadenken of spelen. 

de unieke playstyle dat je frans bent

# 3. Schets van je level en UI 

Maak een schets op papier of digitaal en voeg deze afbeelding toe aan je repository. Voeg in deze sectie de afbeelding in. 

Je schets bevat minimaal: 

Het pad waar de vijanden over lopen met beginpunt en eindpunt. 

De plaatsen waar torens gebouwd kunnen worden. 

De locatie van de basis of goal die verdedigd moet worden. 

De UI onderdelen geld, wave teller, levens, startknop en pauzeknop. 

Een legenda met symbolen of kleuren voor torens, vijanden, pad, basis en UI.

![image1](/readmevfx/tutoriallevelsktech.png)

# 4. Torens 

Toren 1 naam, bereik, schade, unieke eigenschap. 

Archers, medium, 10/2sec, basic tower

Toren 2 naam, bereik, schade, unieke eigenschap. 

Canon, small 50/5sec, damage tower

Eventuele extra torens: 

komt er later erbij ideen krijgen wij altijd tijdens het developen

# 5. Vijanden 

Vijand 1 naam, snelheid, levens, speciale eigenschap. 

tiny orkling, medium speed, 50 health, basic enemy unit

Vijand 2 naam, snelheid, levens, speciale eigenschap.

big giant ork, slow, 200 health, tank unit

Eventuele extra vijanden: 

komt ook later erbij

# 6. Gameplay loop 

Beschrijf in drie tot vijf stappen wat de speler steeds doet.
1. towers plaatsen
2. vijanden verslaan
3. towers upgraden
4. level overleven
5. repeat 

# 7. Progressie 

Leg uit hoe het spel moeilijker wordt naarmate de waves doorgaan. Denk aan sterkere vijanden, kortere tussenpozen, hogere kosten of lagere beloningen. 

precis wat er staat de vijandens main army komt altijd dichter bij dus worden ook de waves elk level starker en de speler moet zich beter voorbereiden

# 8. Risico’s en oplossingen volgens PIO 

Probleem 1: geen geld over

Impact: geen towers plaatsen kunnen om de vijanden te verslaan

Oplossing: spaar en plan goed je geld in

Probleem 2: geen health meer over

Impact: de vijanden hebben jouw basis geconquored. je moet opnieuw beginnen

Oplossing: stay alive

Probleem 3: alle towers in de begin plaatsen

Impact: het zouden ook snelle enemys komen kunnen die snel daar langs rennen

Oplossing: verspreid jouw towers

# 9. Planning per sprint en mechanics 

Schrijf per sprint welke mechanics jij oplevert in de build. Denk aan voorbeelden zoals vijandbeweging over een pad, torens plaatsen, doel kiezen en schieten, waves starten, UI voor geld en levens, upgrades, jouw unieke feature. 

Sprint 1 mechanics: 

Sprint 2 mechanics: 

Sprint 3 mechanics: 

Sprint 4 mechanics: 

Sprint 5 mechanics: 

# 10. Inspiratie 

Noem een bestaande tower defense game die jou inspireert en wat je daarvan meeneemt of juist vermijdt. 

> Kingdom Rush

# 11. Technisch ontwerp mini 

Lees dit korte voorbeeld en vul daarna jouw eigen keuzes in. 

Voorbeeld ingevuld bij 11.1 Vijandbeweging over het pad 

Keuze: Vijanden volgen punten A, B, C en daarna de goal. 

Risico: Een vijand loopt een punt voorbij of blijft hangen. 

Oplossing: Als de vijand dichtbij genoeg is kiest hij het volgende punt. Bij de goal gaat één leven omlaag en verdwijnt de vijand. 

Acceptatie: Tien vijanden lopen van start naar de goal zonder vastlopers en verbruiken elk één leven. Alle tien vijanden bereiken achtereenvolgens elk waypoint binnen één seconde na elkaar. 

## 11.1 Vijandbeweging over het pad 

Keuze: vijanden volgen of een navmesh of punten van wie de players basis de laatste is

Risico: vijand blijfen hangen of zijn stuck

Oplossing: de punten goed placen 

Acceptatie: niet te veel vijanden plaatsen en geen collisie tussen vijanden

 

## 11.2 Doel kiezen en schieten 

Keuze: de eerste enemy die de trigger raakt wordt het doel en als hij het verlaat wordt de volgende enemy die in de trigger was/komt het doel

Risico: te veel enemys zouden een chaos worden

Oplossing: minder enemys op een plek en meer uitspreiden

Acceptatie: ja

## 11.3 Waves en spawnen 

Keuze: enemys spawnen off screen en als alle vijanden game objects verslaan zijn komt de volgende wave

Risico: vijanden die off screen spawnen zouden uit de map buggen kunnen

Oplossing: vijanden erg dichtbij de begin van de pad spawnen

Acceptatie: ja

## 11.4 Economie en levens 

Keuze: bij elk verslaande vijand krijg je munten bij en bij het begin krijg me start munten

Risico: de player kan te snel zijn munten uitgeven

Oplossing: een basic economy opzetten zodat de speler denken moet

Acceptatie: ja

## 11.5 UI basis 

Keuze: ui on top en bij een klik van een tower popt UI op

Risico: de screen scale zou de ui kunnen verplaatsen

Oplossing: de ui uniek scalen

Acceptatie: ja