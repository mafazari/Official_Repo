int disp1 = 3;
int disp1R = 4;
int disp2 = 5;
int disp2R = 6;
int disp3 = 8;
int disp3R = 9;
int tens;
int twenties;
int fifties;
String amountString;
int amount;
int tensInDisp = 10;
int twentiesInDisp = 7;
int fiftiesInDisp = 6;

void setup() {
  // put your setup code here, to run once:
  pinMode(disp2, OUTPUT);
  pinMode(disp2R, OUTPUT);
  pinMode(disp1, OUTPUT);
  pinMode(disp1R, OUTPUT);
  pinMode(disp3, OUTPUT);
  pinMode(disp3R, OUTPUT);
  digitalWrite(disp1R, LOW);
  digitalWrite(disp2R, LOW);
  digitalWrite(disp3R, LOW);
  Serial.begin(9600);
  while (!Serial) //check voor een aangesloten serial connection
  {
    Serial.println("Please connect to serial port");
  }
}

void loop() {
  amountString = Serial.readString();
  Serial.println(amountString);
  amount = amountString.toInt();
 // dispenseAll(amount);

 
  
  if (tensInDisp == 0)
  {
  Serial.println("Geen biljetten beschikbaar");
  dispenseNoTen(amount);
  } 
  
  else if (twentiesInDisp == 0)
  {
   Serial.println("Geen biljetten beschikbaar");
   dispenseNoTwenty(amount);
  }
  
  else if (fiftiesInDisp == 0)
  {
    Serial.println();
    dispenseNoFifty(amount);
  }
  
  else
  {
    dispenseAll(amount);
  } 

  if (tensInDisp == 0 && twentiesInDisp == 0 && fiftiesInDisp == 0)
  {
    Serial.write("Amount cannot be dispensed, refill dispenser");
  }
}

void dispenseAll(int amount) {
  
      Serial.print("Amount to dispense:");
      Serial.println(amount, DEC);
  
      fifties = amount/50;
      amount -= (50*fifties);
  
      twenties = amount/20;
      amount -= (20*twenties);
 
      tens = amount/10;
       amount -= (10*tens);
    
       Serial.println(fifties);
       Serial.println(twenties);
       Serial.println(tens);
       giveTen(tens);
       giveTwenty(twenties);
       giveFifty(fifties);
}

void dispenseNoFifty(int amount) {
  
    Serial.print("Amount to dispense:");
    Serial.println(amount, DEC);
  
    twenties = amount/20;
    amount -= (20*twenties);
 
    tens = amount/10;
    amount -= (10*tens);
  
  if(amount != 0)
  {
    Serial.print("Cannot be dispensed");
  }
  else
  {
    giveTen(tens);
    giveTwenty(twenties); 
  }
}

void dispenseNoTwenty(int amount) {
  
    Serial.print("Amount to dispense:");
    Serial.println(amount, DEC);
  
    fifties = amount/50;
    amount -= (50*fifties);
   
    tens = amount/10;
    amount -= (10*tens);
    
  if(amount != 0)
  {
    Serial.print("Cannot be dispensed");
  }
  else
  {   
    giveTen(tens);
    giveFifty(fifties); 
  }

}

void dispenseNoTen(int amount) {
  
    Serial.print("Amount to dispense:");
    Serial.println(amount, DEC);
    fifties = amount/50;
    amount -= (50*fifties);
  
    twenties = amount/20;
    amount -= (20*twenties);
    
  if(amount != 0) 
  {
    Serial.print("Cannot be dispensed");
  }
    else
  {
       giveTwenty(twenties);
       giveFifty(fifties);
  } 
}

void giveTen(int biljetten) {
  for(int i = 0; i < biljetten; i++)
  {
  digitalWrite(disp1, HIGH);
  delay(1250);
  digitalWrite(disp1, LOW);

  digitalWrite(disp1R, HIGH);
  delay(750);
  digitalWrite(disp1R, LOW);
  
  tensInDisp--;
  }
}

void giveTwenty(int biljetten) {
  for(int i = 0; i < biljetten; i++) 
  {
  digitalWrite(disp2, HIGH);
  delay(2000);
  digitalWrite(disp2, LOW);

  digitalWrite(disp2R, HIGH);
  delay(1250);
  digitalWrite(disp2R, LOW);
  
  twentiesInDisp--;
  }
}

void giveFifty(int biljetten) {
  for(int i = 0; i < biljetten; i++) 
  {
  digitalWrite(disp3, HIGH);
  delay(1250);
  digitalWrite(disp3, LOW);

  digitalWrite(disp3R, HIGH);
  delay(750);
  digitalWrite(disp3R, LOW);
  
  fiftiesInDisp--;
  
  }
}

 void checkInput() {
  
    Serial.readString();
    amount = amountString.toInt();

    if (amount > 350)
    {
      Serial.println("amount too large");
    }
 }

