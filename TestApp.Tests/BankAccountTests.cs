using System;
using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void Test_Constructor_InitialBalanceIsSet()
        {
            // Arrange
            double initialBalance = 100.0;

            // Act
            var account = new BankAccount(initialBalance);

            // Assert
            Assert.AreEqual(initialBalance, account.Balance);
        }

        [Test]
        public void Test_Deposit_PositiveAmount_IncreasesBalance()
        {
            // Arrange
            double initialBalance = 100.0;
            var account = new BankAccount(initialBalance);
            double depositAmount = 50.0;

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(initialBalance + depositAmount, account.Balance);
        }

        [Test]
        public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
        {
            // Arrange
            double initialBalance = 100.0;
            var account = new BankAccount(initialBalance);
            double depositAmount = -50.0;

            // Act & Assert
             Assert.That(() => account.Deposit(depositAmount), Throws.ArgumentException);
            // Assert.That(account.Deposit(depositAmount), () =>Throws new ArgumentException());
        }

        [Test]
        public void Test_Withdraw_ValidAmount_DecreasesBalance()
        {
            // Arrange
            double initialBalance = 100.0;
            var account = new BankAccount(initialBalance);
            double withdrawalAmount = 50.0;

            // Act
            account.Withdraw(withdrawalAmount);

            // Assert
            Assert.AreEqual(initialBalance - withdrawalAmount, account.Balance);
        }

        [Test]
        public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            // Arrange
            double initialBalance = 100.0;
            var account = new BankAccount(initialBalance);
            double withdrawalAmount = -50.0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(withdrawalAmount));
        }

        [Test]
        public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
        {
            // Arrange
            double initialBalance = 100.0;
            var account = new BankAccount(initialBalance);
            double withdrawalAmount = 150.0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(withdrawalAmount));
        }
    }
}
