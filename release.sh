#!/bin/bash   
set -v

if [[ $# -eq 0 ]] ; then
    echo "Please supply login@IP (e.g. pi@192.168.1.2)"
    exit 1
fi

RaspberryPi=$1

ssh $RaspberryPi "sudo systemctl stop red"
ssh $RaspberryPi "sudo systemctl disable red"
ssh $RaspberryPi "rm -rf red"
ssh $RaspberryPi "mkdir red"
scp -r ./stage/red/* $RaspberryPi:red/
ssh $RaspberryPi "chmod 755 ./red/red"
scp ./stage/red.service $RaspberryPi:
ssh $RaspberryPi "sudo mv red.service /lib/systemd/system/red.service"
ssh $RaspberryPi "sudo systemctl enable red"
ssh $RaspberryPi "sudo systemctl start red"