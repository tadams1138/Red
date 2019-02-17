#!/bin/bash   
set -v

if [[ $# -eq 0 ]] ; then
    echo "Please supply login@IP (e.g. pi@192.168.1.2)"
    exit 1
fi

RaspberryPi=$1

ssh $RaspberryPi "sudo systemctl stop Red"
ssh $RaspberryPi "sudo systemctl disable Red"
ssh $RaspberryPi "rm -rf Red"
ssh $RaspberryPi "mkdir Red"
scp -r ./stage/Red* $RaspberryPi:Red/
ssh $RaspberryPi "chmod 755 ./Red/Red"
scp ./stage/Red.service $RaspberryPi:
ssh $RaspberryPi "sudo mv Red.service /lib/systemd/system/"
ssh $RaspberryPi "sudo systemctl enable Red"
ssh $RaspberryPi "sudo systemctl start Red"