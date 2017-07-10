import urllib2
import StringIO
from bs4 import BeautifulSoup
import sys
import csv

url = "http://www.stats.gov.cn/tjsj/tjbz/tjyqhdmhcxhfdm/2016/"
request = urllib2.Request(url)
request.add_header("User-Agent","Mozilla/5.0")

try: 
	response = urllib2.urlopen(request)
	print response.getcode()
	content = response.read()
	print content
except Exception,e: 
	print e.reason

content=content.decode("GB2312","lxml")
#soup = BeautifulSoup(content)
soup = BeautifulSoup(content)
tds = soup.findAll("td")
for td in tds:
    print td
