#-*- coding: utf-8 -*-

#1) Download python here - https://www.anaconda.com/distribution/     
#(Be sure that you get the version of anaconda for your OS)

#2) Install requests, beautiful soup and selenium using pip.
#Open command prompt (or anaconda prompt or terminal) 
#and enter the command 'pip install selenium', 'pip install bs4' and 'pip install requests' 
#all without the quotes.

import requests
import json
import time
import sys
from selenium import webdriver
#веселый факт:
#предложение подписаться на рассылку крашит весь скрипт
#появилось в первый раз за сессий 20-30
#надо обработать





def availabilityCheck(productToFind):#эта функция будет выполняться, пока не вернет url (через while true и break)
    r = requests.get('https://www.deadstock.ca/products.json?limit=50&page=1')
    products = json.loads((r.text))['products']

    for product in products:
        productName = product['title']
        if productName == productToFind:
            producturl = 'https://www.deadstock.ca/products/' + product['handle']
            print('Found item')
            return producturl    
    return False

def buyProduct(producturl):#сюда будет передаваться url, по которому бот будет покупать 
    driver = webdriver.Chrome(executable_path=r'D:\Учеба\Перлов\ShopBot\chromedriver.exe')#вставить путь
    driver.get(producturl)
    #Сделать перебор по размерам?
    driver.find_element_by_xpath('//label[@for="ProductSelect-option-US Size-9"]').click()
    driver.find_element_by_xpath('//button[@id="AddToCart"]').click()
    time.sleep(2)
    driver.get('https://www.deadstock.ca/cart')
    driver.find_element_by_xpath('//button[@name="checkout"]').click()
    #здесь пошли персональные данные
    #я бы еще задержек навставлял между персональными данными, т.к. поле может нечаянно неполностью заполниться(один раз такое было)




    driver.find_element_by_xpath('//input[@placeholder="Email"]').send_keys(email)
    time.sleep(1)
    driver.find_element_by_xpath('//input[@placeholder="First name"]').send_keys(firstName)
    time.sleep(1)
    driver.find_element_by_xpath('//input[@placeholder="Last name"]').send_keys(secondName)
    time.sleep(1)
    driver.find_element_by_xpath('//input[@placeholder="Address"]').send_keys(address)
    time.sleep(1)
    #driver.find_element_by_xpath('//input[@placeholder="Apartment, suite, etc. (optional)"]').send_keys('STE 741262')
    #time.sleep(1)
    driver.find_element_by_xpath('//input[@placeholder="City"]').send_keys(city)
    time.sleep(1)
    driver.find_element_by_xpath('//select[@data-trekkie-id="shipping_country_field"]').send_keys(country)
    time.sleep(1)
    driver.find_element_by_xpath('//select[@placeholder="State"]').send_keys(state)
    time.sleep(1)
    driver.find_element_by_xpath('//input[@placeholder="ZIP code"]').send_keys(zipCode)
    time.sleep(2)
    driver.find_element_by_xpath('//input[@placeholder="Phone"]').send_keys(phone + u'\ue007')
    time.sleep(2)
    #выбор доставки
    driver.find_element_by_xpath('//span[@data-shipping-method-label-title="FREE - FedEx Ground 5 - 7 Day"]').click()
    time.sleep(1)
    driver.find_element_by_xpath('//button[@data-trekkie-id="continue_to_payment_method_button"]').click()
    time.sleep(10)
    #заполнение данных для оплаты (пока не работает, не удается найти правильный путь к элементам) 
    driver.find_element_by_xpath('//input[@autocomplete="cc-number"]').send_keys('1234123412344321')
    time.sleep(1)
    driver.find_element_by_xpath('//input[@autocomplete="cc-name"]').send_keys('VASYA PETROV')
    time.sleep(1)
    driver.find_element_by_xpath('//div[@data-card-field-placeholder="Expiration date (MM / YY)"]').send_keys('0121')
    time.sleep(1)
    driver.find_element_by_xpath('//div[@data-card-field-placeholder="Security code"]').send_keys('991')
    time.sleep(1)

#------------

#наименование продукта, необходимого для покупки
#productToFind = 'Nike MX-720-818 Metallic Silver / Black'

#productToFind = input() # продукт для поиска
#firstName = input()  # имя
#secondName = input()  # фамилия
#email = input()  # почта
#phone = input()  # телефон
#zipCode = input()  # почтовый индекс
#country = input()  # страна
#state = input()  # штат
#city = input()  # город
#address = input()  # адрес
# card = input() #карта

productToFind = sys.argv[1] # продукт для поиска
firstName = sys.argv[2]  # имя
secondName = sys.argv[3]  # фамилия
email = sys.argv[4]  # почта
phone = sys.argv[5]  # телефон
zipCode = sys.argv[6] # почтовый индекс
country = sys.argv[7]  # страна
state = sys.argv[8]  # штат
city = sys.argv[9]  # город
address = sys.argv[10]  # адрес
#card = sys.argv[11] #карта





while True:
    myUrl = availabilityCheck(productToFind)
    if myUrl != False:
        buyProduct(myUrl)
        break
    else:
        time.sleep(1)
    