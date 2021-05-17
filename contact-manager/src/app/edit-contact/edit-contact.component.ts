import { Component, Input, OnInit } from '@angular/core';
import { Contactos } from '../shared/Contactos';
import { ContactMock } from '../shared/mocks/contactos-mock';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {
  items !: Contactos[]
  @Input() selectedContactItem !: Contactos;
  constructor() { }

  ngOnInit(): void {
    this.items = ContactMock;
  }
  onClick(selectedcontactitem: Contactos){
    let del = this.items?.findIndex(p => p == selectedcontactitem);
    this.items?.splice(del,1);
    this.selectedContactItem !=  undefined;
  
  }

}
