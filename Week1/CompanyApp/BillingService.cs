using System;

class BillingService
{
    //  Electricity Bill (New Logic)
    public double CalculateElectricityBill(int units)
    {
        double bill = 50; // fixed meter charge

        if (units <= 100)
            bill += units * 2;
        else if (units <= 300)
            bill += (100 * 2) + ((units - 100) * 3);
        else
            bill += (100 * 2) + (200 * 3) + ((units - 300) * 5);

        return bill;
    }

    // Mobile Bill (New Logic)
    public double CalculateMobileBill(int minutes, int sms)
    {
        double bill = 199; // base plan

        if (minutes > 100)
            bill += (minutes - 100) * 1.2;

        if (sms > 50)
            bill += (sms - 50) * 0.75;

        return bill;
    }

    // Internet Bill (New Logic)
    public double CalculateInternetBill(double dataUsedInGB)
    {
        double bill = 799; // base plan

        if (dataUsedInGB > 100)
            bill += (dataUsedInGB - 100) * 15;

        return bill;
    }

    // Insurance Premium (New Logic)
    public double CalculateInsurancePremium(int age, double amount)
    {
        double premiumRate = 0.05;

        if (age > 60)
            premiumRate += 0.04;
        else if (age > 40)
            premiumRate += 0.02;

        return amount * premiumRate;
    }
}

