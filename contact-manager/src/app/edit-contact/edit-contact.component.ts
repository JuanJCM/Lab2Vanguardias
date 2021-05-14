import { Component, Input, OnInit } from '@angular/core';
import { Contactos } from '../shared/Contactos';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {

  @Input() selectedContactItem !: Contactos;
  constructor() { }

  ngOnInit(): void {
  }
  onClick(selectedcontactitem: Contactos){
    
  }

}
