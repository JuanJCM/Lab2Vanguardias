import { Component, OnInit } from '@angular/core';
import { Contactos } from '../shared/Contactos';
import { ContactMock } from '../shared/mocks/contactos-mock';

@Component({
  selector: 'app-contact-manager',
  templateUrl: './contact-manager.component.html',
  styleUrls: ['./contact-manager.component.css']
})
export class ContactManagerComponent implements OnInit {
  items!: Contactos[];
  title: string = "Contactos";
  selectedContactItem !: Contactos;

  constructor() { }

  ngOnInit(): void {
    this.items = ContactMock; 
  }
  onSelect(contact: Contactos){
    this.selectedContactItem = contact;
  }
}
