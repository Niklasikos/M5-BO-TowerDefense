# Sprint 0 - Game Design Document : Tower Defense 

Naam: Niklas Nikolaidis 

Klas: SD2A

Datum: 7-9-2026

# 1. Titel en elevator pitch 

Titel: Tour de défense 
>(Tower defense maar je bent french)

Het is een normale Tower Defense maar je bent een franse generaal die de Vijanden(Orks, Skeletons, mad mages and tanks) verslaan moet, je bouwt towers, defense en overleeft de battles.

# 2. Wat maakt jouw tower defense uniek 

Er is niet erg een unieke playstyle misschien een iets grotere map en dan een RTS camera movement 

# 3. Schets van je level en UI 

![image1](/readmevfx/tutoriallevelsktech.png)

# 4. Torens 

Archers, medium, 10/2sec, basic tower

Canon, small 50/5sec, damage tower

Mage, big, 5/2s + Slow eefect, effect tower

# 5. Vijanden 

tiny orkling, medium speed, 50 health, basic enemy unit

big giant ork, slow, 200 health, tank unit

Mad Mage, medium, 75 health, can stun towers

# 6. Gameplay loop 

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

Sprint 1 mechanics: Vijand01, Tower01, Spawner, Health, Coins

Sprint 2 mechanics: 

Sprint 3 mechanics: 

Sprint 4 mechanics: 

Sprint 5 mechanics: 

# 10. Inspiratie 

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