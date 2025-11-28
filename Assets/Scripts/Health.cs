using System;
using Unity.Android.Gradle.Manifest;
using Action = System.Action;

public class Health
{
    private int _currentHealth;
    private readonly int _maxHealth;
    public event Action<int, int> OnHealthChanged;
    public Health(int maxHealth)
    {
        this._maxHealth = maxHealth;
        this._currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
        }
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }
}