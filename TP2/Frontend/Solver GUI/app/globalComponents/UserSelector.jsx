import React from 'react';
import { FormGroup, FormControl, ControlLabel } from 'react-bootstrap';
import ListUserOptions from './ListUserOptions';

const UserSelector = (props) => {
    return (
        <FormGroup>
            <ControlLabel>Author</ControlLabel>
            <FormControl value={props.value} onChange={props.onChange} componentClass="select" placeholder="Enter username" name="author">
                <ListUserOptions userType={props.userType}/>
            </FormControl>
        </FormGroup>
    );
}

export default UserSelector;