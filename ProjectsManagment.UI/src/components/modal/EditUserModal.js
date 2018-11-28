import React  from "react";
import Modal from './Modal';

const EditUserModal = ({ show, handleClose, editUser,handleFormSubmit }) => {
    return (
            <Modal show={show} handleClose={handleClose}>
                <form>
                        <input
                            className="form-item"
                            name="FirstName"
                            type="text"
                            defaultValue={editUser.FirstName}
                        />
                        <input
                            className="form-item"
                            name="LastName"
                            type="text"
                            defaultValue={editUser.LastName}
                            
                        />
                        <input
                            className="form-submit"
                            value="SUBMIT"
                            type="submit"
                            onClick={(event) => handleFormSubmit(event)}
                         />
                    </form>
              </Modal>
              );
    }

    export default EditUserModal;